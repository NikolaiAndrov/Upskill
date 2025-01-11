namespace PostRequestApi
{
    using System.Text;
    using System.Text.Json;

    public class StartUp
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            await PostApi(client);
            Console.WriteLine();
            await GetApi(client);

            client.Dispose();
        }

        static async Task GetApi(HttpClient client)
        {
            HttpResponseMessage result = client.GetAsync("posts").Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonStr = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Get result:");
                Console.WriteLine(jsonStr);
            }
        }

        static async Task PostApi(HttpClient client)
        {
            PostData postData = new PostData
            {
                Name = "John Doe",
                Age = 30,
                Address = "123 Elm St."
            };

            string jsonStr = JsonSerializer.Serialize(postData);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("posts", content).Result;

            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                string responseStr = await response.Content.ReadAsStringAsync();
                PostResponse? postResponse = JsonSerializer.Deserialize<PostResponse>(responseStr, options);

                if (postResponse != null)
                {
                    Console.WriteLine("Post result:");
                    Console.WriteLine($"Id {postResponse.Id}");
                }
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}");
            }
        }
    }
}
