using System;
using System.Diagnostics;
using System.IO;

namespace AsyncFileStream
{
    public static class ApmReadWriteFileStream
    {
        public static void Run(string fileName, byte[] buffer)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("* Running asynchronous file operations (APM model).");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Read more:
            // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/polling-for-the-status-of-an-asynchronous-operation
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true))
            {
                Console.WriteLine($"Writing {buffer.Length} bytes...");
                stopwatch.Start();
                var result = fs.BeginWrite(buffer, 0, buffer.Length, null, null);

                // TODO block the execution by polling for IsCompleted operation status.

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            // Read more:
            // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/blocking-application-execution-by-ending-an-async-operation
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();
                var result = fs.BeginRead(buffer, 0, buffer.Length, null, null);

                // TODO block the execution by ending an async operation.
                
                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            // Read more:
            // https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/blocking-application-execution-using-an-asyncwaithandle
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();
                
                var result = fs.BeginRead(buffer, 0, buffer.Length, null, null);

                // TODO block the execution using AsyncWaitHandle.

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            File.Delete(fileName);
        }
    }
}
