using FinanceApp.classes;
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
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
