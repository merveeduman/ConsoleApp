using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var client = new HttpClient();

        while (true)
        {
            Console.WriteLine("\nselect the option :");
             Console.WriteLine("1 - Category");
            Console.WriteLine("2 - Country");
            Console.WriteLine("3 - Owner");
            Console.WriteLine("4 - Pokemon");
            Console.WriteLine("5 - Review");
            Console.WriteLine("6 - Reviewer");
            Console.WriteLine("0 - stop");
            Console.Write("Selection: ");

            string input = Console.ReadLine();

            if (input == "0")
                break;
  

            string endpoint = input switch
            {
                "1" => "Category",
                "2" => "Country",
                "3" => "Owner",
                "4" => "Pokemon",
                "5" => "Review",
                "6" => "Reviewer",
                _ => null
            };

            if (endpoint == null)
            {
                Console.WriteLine("enter the number between 1-6 ");
                continue;
            }

            try
            {
                var response = await client.GetAsync($"https://localhost:7091/api/{endpoint}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\n data from the API:");
                Console.WriteLine(content);
            }

            catch (Exception ex)
            {
                Console.WriteLine($" ERROR: {ex.Message}");
            }

            Console.WriteLine("\n enter the any value...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
