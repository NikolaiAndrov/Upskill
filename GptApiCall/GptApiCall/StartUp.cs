namespace GptApiCall
{
    using System.Text;
    using System.Text.Json;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            string apiKey = "";
            string apiUrl = @"https://api.openai.com/v1/chat/completions";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                while (true)
                {
                    Console.WriteLine("Enter your question (or type 'exit' to quit):");
                    string userInput = Console.ReadLine();

                    if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    var requestBody = new
                    {
                        model = "gpt-4o-mini",
                        messages = new[]
                        {
                            new { role = "system", content = "You are a helpful assistant." },
                            new { role = "user", content = userInput }
                        },
                        max_tokens = 50
                    };

                    string jsonRequestBody = JsonSerializer.Serialize(requestBody);
                    var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            using var doc = JsonDocument.Parse(responseContent);
                            var reply = doc.RootElement
                                           .GetProperty("choices")[0]
                                           .GetProperty("message")
                                           .GetProperty("content")
                                           .GetString();
                            Console.WriteLine("Response from GPT:");
                            Console.WriteLine(reply);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode}");
                            string errorContent = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(errorContent);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred:");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
