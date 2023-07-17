
using System.Net;
using System.Net.Sockets;

namespace NetworkingApplication
{
    public class NetworkingException : Exception
    {
        public NetworkingException(string message) : base(message)
        {

        }
    }

    public class NetworkConnector
    {
        public void EstablishConnection(string ipAddress, int port)
        {
            try
            {
                IPAddress serverIpAddress;
                if (!IPAddress.TryParse(ipAddress, out serverIpAddress))
                {
                    throw new NetworkingException("Invalid IP address format.");
                }

                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(serverIpAddress, port);
                    Console.WriteLine("Connection established successfully.");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Failed to establish a connection:");
                Console.WriteLine(ex.StackTrace);
            }
            catch (NetworkingException ex)
            {
                Console.WriteLine($"Failed to establish a connection: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NetworkConnector networkConnector = new NetworkConnector();

            // Network connection
            string validIpAddress = "192.168.1.10";
            string invalidIpAddress = "invalid_ip_address";
            int validPort = 8888;
            int invalidPort = -1;

            networkConnector.EstablishConnection(validIpAddress, validPort);
            Console.WriteLine();

            networkConnector.EstablishConnection(invalidIpAddress, validPort);
            Console.WriteLine();

            networkConnector.EstablishConnection(validIpAddress, invalidPort);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
