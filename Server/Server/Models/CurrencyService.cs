using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Server.Models
{
    public static class CurrencyService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static System.Timers.Timer timer;

        public static Currency currencyRate;

        public static async Task Start()
        {
            await ExecuteAsync();
            Console.WriteLine(currencyRate);
            timer = new System.Timers.Timer(3600000); // Corrected interval
            timer.Elapsed += async (sender, e) => await ExecuteAsync();
            timer.Start();
        }

        public static async Task<Currency> ExecuteAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://belarusbank.by/api/kursExchange");
                response.EnsureSuccessStatusCode();
                string ExchangeRateJSON = await response.Content.ReadAsStringAsync();
                List<Currency> rates = JsonConvert.DeserializeObject<List<Currency>>(ExchangeRateJSON);
                if (rates.Count > 0)
                {
                    currencyRate = rates[0];
                    Console.WriteLine(rates[0]);
                }
                else
                {
                    Console.WriteLine("No exchange rates found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching exchange rates: {ex.Message}");
            }
            return currencyRate;
        }
    }
}
