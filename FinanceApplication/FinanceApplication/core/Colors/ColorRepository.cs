using Android.Content;
using FinanceApp.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                List<Colorss> colors = JsonConvert.DeserializeObject<List<Colorss>>(ColorsJson);
                
                foreach (var item in colors)
                {
                    Console.WriteLine(item);
                }


                return colors;
            }
            else
            {
                return null;
            }
        }
    }
}
