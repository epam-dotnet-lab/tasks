using System;
using System.Diagnostics;
using System.IO;

namespace AsyncFileStream
{
    public static class AsyncReadWriteFileStream
    {
        // Read more:
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model
        // TODO - make this method async and rename to RunAsync.
        // TODO - after completing the task, add breakpoints before and after WriteAsync and ReadAsync methods, and use Debug\Windows\Threads windows to investigate threads behaviour.
        public static void Run(string fileName, byte[] buffer)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("* Running asynchronous file operations (async/await).");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true))
            {
                Console.WriteLine($"Writing {buffer.Length} bytes...");
                stopwatch.Start();
                
                // TODO - use WriteAsync and await keyword.
                fs.Write(buffer, 0, buffer.Length);
                
                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();
                
                // TODO - use ReadAsync and await keyword.
                fs.Read(buffer, 0, buffer.Length);
                
                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32, true))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();
                
                // TODO - use ReadAsync and await keyword.
                fs.Read(buffer, 0, buffer.Length);
                
                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            File.Delete(fileName);
        }
    }
}
