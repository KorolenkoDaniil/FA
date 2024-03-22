using FinanceApp.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApplication.core.Category
{
    public class CategoryRepository
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async static Task<bool> SaveCategory(Category newCategory)
        {
            string CategoryJson = JsonConvert.SerializeObject(newCategory);
            var content = new StringContent(CategoryJson, Encoding.UTF8, "application/json");

            Console.WriteLine(newCategory);
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveCategory, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
                return true;
            }
            else return false;
        }

        public async static Task<List<Category>> GetCategorys(int userId)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                {"id", userId.ToString()}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetCategories, form);

            if (response.IsSuccessStatusCode)
            {
                string CategoriessJson = await response.Content.ReadAsStringAsync();
                List<Category> userCategories = JsonConvert.DeserializeObject<List<Category>>(CategoriessJson);
                foreach (Category Category in userCategories)
                {
                    Console.WriteLine(Category);
                }
                return userCategories;
            }
            else
            {
                return null;
            }
        }
    }
}
