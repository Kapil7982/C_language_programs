using System;
using System.IO;

namespace DataExport
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
        }
    }

    public class FileIOException : Exception
    {
        public FileIOException(string message) : base(message)
        {
        }
        public FileIOException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class DataExportTool
    {
        private const string DatabaseConnectionString = "Server=8888;Database=ecm;Uid=root;Pwd=port";
        private const string ExportFilePath = "data.txt";

        public void ExportData()
        {
            try
            {
                Console.WriteLine("Connecting to the database...");
                ConnectToDatabase();

                Console.WriteLine("Reading data from the database...");
                string data = ReadDataFromDatabase();

                Console.WriteLine("Processing data...");
                string processedData = ProcessData(data);

                Console.WriteLine("Exporting data to a file...");
                WriteDataToFile(processedData);

                Console.WriteLine("Data export completed successfully.");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine($"Database error occurred: {ex.Message}");
            }
            catch (FileIOException ex)
            {
                Console.WriteLine($"File I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during data export: {ex.Message}");
            }
        }

        private void ConnectToDatabase()
        {
            // Database connection 
            throw new DatabaseException("Unable to establish a database connection.");
        }

        private string ReadDataFromDatabase()
        {
            // Database query 
            return "Data from the database";
        }

        private string ProcessData(string data)
        {
            // Data processing 
            return $"Processed data: {data}";
        }

        private void WriteDataToFile(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ExportFilePath))
                {
                    writer.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                throw new FileIOException("Unable to write data to the file.", ex);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataExportTool dataExportTool = new DataExportTool();
            dataExportTool.ExportData();

            Console.ReadLine();
        }
    }
}
