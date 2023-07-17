
using System.Runtime.Serialization.Formatters.Binary;

namespace ConfigurationManagement
{
    [Serializable]
    public class ConfigurationSettings
    {
        public string ApplicationName { get; set; }
        public string DatabaseConnecton { get; set; }
        public int MaxConnections { get; set; }

        public ConfigurationSettings(string appName, string dbConnection, int maxConn)
        {
            ApplicationName = appName;
            DatabaseConnecton = dbConnection;
            MaxConnections = maxConn;
        }
    }

    public class ConfigurationSerializer
    {
        public void SerializeConfiguration(ConfigurationSettings settings, string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, settings);
                }

                Console.WriteLine("Configuration settings serialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during serialization: {ex.Message}");
            }
        }

        public ConfigurationSettings DeserializeConfiguration(string filePath)
        {
            ConfigurationSettings settings = null;

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    settings = (ConfigurationSettings)formatter.Deserialize(fileStream);
                }

                Console.WriteLine("Configuration settings deserialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during deserialization: {ex.Message}");
            }

            return settings;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "mock.bin";

            ConfigurationSettings initialSettings = new ConfigurationSettings("MyApp", "server=myserver;database=mydb", 10);

            ConfigurationSerializer serializer = new ConfigurationSerializer();
            serializer.SerializeConfiguration(initialSettings, filePath);

            ConfigurationSettings deserializedSettings = serializer.DeserializeConfiguration(filePath);

            if (deserializedSettings != null)
            {
                Console.WriteLine($"Deserialized Configuration Settings:\n" +
                                  $"Application Name: {deserializedSettings.ApplicationName}\n" +
                                  $"Database Connection String: {deserializedSettings.DatabaseConnecton}\n" +
                                  $"Max Connections: {deserializedSettings.MaxConnections}");
            }

            Console.ReadLine();
        }
    }
}
