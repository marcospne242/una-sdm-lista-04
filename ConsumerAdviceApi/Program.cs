using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumerAdviceApi
{
    public class AdviceSlip
    {
        [JsonPropertyName("slip")]
        public Slip Slip { get; set; }
    }

    public class Slip
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("advice")]
        public string Advice { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://api.adviceslip.com/advice";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine($"Iniciando requisição para obter dados de um conselho: {url}");
                    
                    string response = await client.GetStringAsync(url);
                   
                    var adviceData = JsonSerializer.Deserialize<AdviceSlip>(response);

                    Console.WriteLine("\nConselho de Hoje:");
                    
                    Console.WriteLine($"{adviceData?.Slip?.Advice}");

                    Console.WriteLine("\nLimpando memória... fim da requisição!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                }
            }
        }
    }
}