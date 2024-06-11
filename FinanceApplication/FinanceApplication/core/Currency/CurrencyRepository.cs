using FinanceApp.classes;
using FinanceApp.classes.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace FinanceApplication.core.Currency
{
    internal class CurrencyRepository
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public async static Task<Currency> GetCurrency()
        {
            Dictionary<string, string> userData = new Dictionary<string, string>();
            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetCurrency, form);
            if (response.IsSuccessStatusCode)
            {
                string CurrencyJson = await response.Content.ReadAsStringAsync();
                Currency currency = JsonConvert.DeserializeObject<Currency>(CurrencyJson);
                Console.WriteLine("курсы--------------");
                Console.WriteLine(currency);
                Console.WriteLine("курсы--------------");
                return currency;
            }
            else
                return null;
        }
    }
}
