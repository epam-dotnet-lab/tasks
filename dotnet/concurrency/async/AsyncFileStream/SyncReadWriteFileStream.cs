using System;
using System.Diagnostics;
using System.IO;

namespace AsyncFileStream
{
    public static class SyncReadWriteFileStream
    {
        public static void Run(string fileName, byte[] buffer)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("* Running synchronous file operations.");

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, false))
            {
                Console.WriteLine($"Writing {buffer.Length} bytes...");
                stopwatch.Start();

                fs.Write(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, false))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();

                fs.Read(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32, false))
            {
                Console.WriteLine($"Reading {buffer.Length} bytes...");
                stopwatch.Restart();

                fs.Read(buffer, 0, buffer.Length);

                stopwatch.Stop();

                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms elapsed.");
            }

            File.Delete(fileName);
        }
    }
}
