using System;
using System.Collections.Generic;
using System.Threading;

namespace ImageProcessing
{
    public class ImageProcessor
    {
        private static readonly object LockObject = new object();

        public void ProcessingImage(string imageFileName)
        {
            Console.WriteLine($"Processing image: {imageFileName}");

            // Image processing by sleeping for a random duration
            Thread.Sleep(TimeSpan.FromSeconds(new Random().Next(1, 5)));

            Console.WriteLine($"Image processing completed: {imageFileName}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> imageFiles = new List<string>
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg",
                "image4.jpg",
                "image5.jpg"
            };

            ImageProcessor imageProcessor = new ImageProcessor();

            // Create and start a separate thread for each image
            List<Thread> threads = new List<Thread>();
            foreach (string imageFile in imageFiles)
            {
                Thread thread = new Thread(() =>
                {
                    // Only one thread accesses shared resources at a time
                    lock (imageProcessor)
                    {
                        imageProcessor.ProcessingImage(imageFile);
                    }
                });

                threads.Add(thread);
                thread.Start();
            }

            // Wait for all threads to complete
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("All image processing tasks completed.");
            Console.ReadLine();
        }
    }
}
