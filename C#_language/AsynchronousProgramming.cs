

namespace WebRequests
{
    public class WebRequestProcessor
    {
        private readonly HttpClient _httpClient;

        public WebRequestProcessor()
        {
            _httpClient = new HttpClient();
        }

        public async Task WebRequestProcessing(List<string> urls)
        {
            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine($"Sending web request to: {url}");
                    string response = await _httpClient.GetStringAsync(url);
                    Console.WriteLine($"Received response from: {url}\nResponse: {response}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while processing web request to: {url}");
                    Console.WriteLine($"Error message: {ex.Message}\n");
                }
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> urls = new List<string>
            {
                "https://www.example.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.invalidurl.com"
            };

            WebRequestProcessor webRequestProcessor = new WebRequestProcessor();

            try
            {
                await webRequestProcessor.WebRequestProcessing(urls);
                Console.WriteLine("All web requests completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing web requests: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
