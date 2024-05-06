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

        public async static Task<Category> SaveCategory(Category newCategory)
        {
            string CategoryJson = JsonConvert.SerializeObject(newCategory);
            var content = new StringContent(CategoryJson, Encoding.UTF8, "application/json");

            //Console.WriteLine(newCategory);
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveCategory, content);

            if (response.IsSuccessStatusCode)
            {
                string categoryJSON = await response.Content.ReadAsStringAsync();
                Category userCategory = JsonConvert.DeserializeObject<Category>(categoryJSON);
                return userCategory;
            }
            else return null;
        }

        public async static Task<List<Category>> GetCategorys(int userId)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                {"id", userId.ToString()}
            };

            List<Category> userCategories = null;
            try
            {
                FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
                HttpResponseMessage response = await httpClient.PostAsync(Links.GetCategories, form);


                if (response.IsSuccessStatusCode)
                {
                    string CategoriessJson = await response.Content.ReadAsStringAsync();
                    userCategories = JsonConvert.DeserializeObject<List<Category>>(CategoriessJson);

                    Console.WriteLine(CategoriessJson);

                    Console.WriteLine("-----категории");
                    foreach (Category categories in userCategories)
                    {
                        Console.WriteLine(categories);
                    }
                    Console.WriteLine("-----категории");

                    return userCategories;
                }
                else return null;
                
            }
            catch (ArgumentException)
            {

            }
            return userCategories;
        }
    }
}
