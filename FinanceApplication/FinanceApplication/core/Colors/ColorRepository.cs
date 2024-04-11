using FinanceApp.classes;
using FinanceApp.classes.Wallets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinanceApplication.core.Colors
{
    public class ColorRepository
    {
        private static readonly HttpClient client = new HttpClient();
        public async static Task<Colorss> GetColor(int colorId)
        {
            Dictionary<string, string> ColorId = new Dictionary<string, string>
            {
                {"id", colorId.ToString()}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(ColorId);
            HttpResponseMessage response = await client.PostAsync(Links.GetColor, form);


            if (response.IsSuccessStatusCode)
            {
                string color = await response.Content.ReadAsStringAsync();
                Colorss result = JsonConvert.DeserializeObject<Colorss>(color);
                Console.WriteLine("----------- цвет");
                Console.WriteLine(result);
                Console.WriteLine("----------- цвет");
                return result;
            }
            else
            {
                return null;
            }
        }

        public async static Task<List<Colorss>> GetColors()
        {
            Dictionary<string, string> EmptyDictionary = new Dictionary<string, string>();
       

            FormUrlEncodedContent form = new FormUrlEncodedContent(EmptyDictionary);
            HttpResponseMessage response = await client.PostAsync(Links.GetColors, form);

            if (response.IsSuccessStatusCode)
            {
                string ColorsJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine("---");
                Console.WriteLine(ColorsJson);
                Console.WriteLine("---");
                List<Colorss> colors = JsonConvert.DeserializeObject<List<Colorss>>(ColorsJson);
                Console.WriteLine("----------- цвет");
                foreach (Colorss color in colors)
                {
                    Console.WriteLine(color);
                }
                Console.WriteLine("----------- цвет");
                return colors;
            }
            else
            {
                return null;
            }
        }
    }
}
