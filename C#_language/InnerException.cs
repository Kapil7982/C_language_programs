using System;
using System.IO;

namespace FileProcessing
{
    public class FileProcessingException : Exception
    {
        public string FilePath { get; }
        public string InnerExceptionMessage { get; }

        public FileProcessingException(string filePath, string innerExceptionMessage)
        {
            FilePath = filePath;
            InnerExceptionMessage = innerExceptionMessage;
        }
    }

    public class FileProcessor
    {
        public void ReadFile(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read and process the file
                    string fileContent = reader.ReadToEnd();
                    Console.WriteLine("File content:");
                    Console.WriteLine(fileContent);
                }
            }
            catch (FileNotFoundException ex)
            {
                string innerExceptionMessage = ex.Message;
                throw new FileProcessingException(filePath, innerExceptionMessage);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fileProcessor = new FileProcessor();

            // File processing 
            string existingFilePath = "data.txt";
            string nonExistingFilePath = "false.txt";

            try
            {
                fileProcessor.ReadFile(existingFilePath);
                Console.WriteLine($"File processing successful: {existingFilePath}");
            }
            catch (FileProcessingException ex)
            {
                Console.WriteLine($"File processing failed: {ex.FilePath}\nInner Exception: {ex.InnerExceptionMessage}");
            }

            try
            {
                fileProcessor.ReadFile(nonExistingFilePath);
                Console.WriteLine($"File processing successful: {nonExistingFilePath}");
            }
            catch (FileProcessingException ex)
            {
                Console.WriteLine($"File processing failed: {ex.FilePath}\nInner Exception: {ex.InnerExceptionMessage}");
            }

            Console.ReadLine();
        }
    }
}


// Output of the above program 

// dotnet run InnerException.cs
// File content:
// My name is kapil.
// File processing successful: data.txt
// File processing failed: false.txt
// Inner Exception: Could not find file 'D:\C#_language\false.txt'.