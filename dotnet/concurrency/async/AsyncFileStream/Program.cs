using System;
using System.Threading.Tasks;

namespace AsyncFileStream
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Use this code for C# version >= 7.1 - with async main method support.
            await Run();

            // Use this code for C# version < 7.1 - with no async main method support.
            // AsyncHelper.RunSync(Run);

            Console.ReadKey();
        }

        private static async Task Run()
        {
            const string fileName = "file.bin";
            const int bufferSize = 1024 * 512;

            byte[] buffer = CreateBuffer(bufferSize);
            
            ReadWriteFileStream.Run(fileName, buffer);

            // TODO (1) uncomment the line below and fix TODO in the method.
            // ApmReadWriteFileStream.Run(fileName, buffer);

            // TODO (2) uncomment the line below and fix TODO in the method.
            // ApmReadWriteCallbacksFileStream.Run(fileName, buffer);

            // TODO (3) uncomment the line below, use await to call it, and fix TODO in the method.
            // AsyncReadWriteFileStream.Run(fileName, buffer);

        }

        private static byte[] CreateBuffer(int bufferSize)
        {
            Console.WriteLine("Prepare a buffer with random numbers");

            var buffer = new byte[bufferSize];

            var random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)random.Next(byte.MaxValue);
            }

            return buffer;
        }
    }
}
