using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AsyncFileStream
{
    public static class ApmReadWriteCallbacksFileStream
    {
        internal class OperationState
        {
            public string FileName;

            public byte[] Buffer;

            public Stopwatch Stopwatch;

            public FileStream FileStream;

            public ManualResetEventSlim ResetEvent;
        }

        public static void Run(string fileName, byte[] buffer)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("* Running asynchronous file operations (APM callback model).");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true);

            Console.WriteLine($"Writing {buffer.Length} bytes...");

            var mre = new ManualResetEventSlim();

            stopwatch.Start();

            fs.BeginWrite(buffer, 0, buffer.Length, new AsyncCallback(WriteOperationCallback), new OperationState
            {
                FileName = fileName,
                Buffer = buffer,
                Stopwatch = stopwatch,
                FileStream = fs,
                ResetEvent = mre
            });

            mre.Wait();

            Console.WriteLine("Callback operations are completed.");
        }

        private static void WriteOperationCallback(IAsyncResult asyncResult)
        {
            var operationState = (OperationState)asyncResult.AsyncState;
            var stopwatch = operationState.Stopwatch;
            var buffer = operationState.Buffer;
            var fileName = operationState.FileName;
            var writeFileStream = operationState.FileStream;

            try
            {
                writeFileStream.EndWrite(asyncResult);
            }
            catch (Exception)
            {
                operationState.ResetEvent.Set();
            }
            finally
            {
                writeFileStream.Dispose();
            }

            stopwatch.Stop();

            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();

                // TODO - create a new callback and use it with BeginRead.
                // Read more:
                // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/using-an-asynccallback-delegate-to-end-an-asynchronous-operation
                fs.Read(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();

                // TODO - create a new callback and use it with BeginRead.
                fs.Read(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            File.Delete(fileName);

            operationState.ResetEvent.Set();
        }
    }
}
