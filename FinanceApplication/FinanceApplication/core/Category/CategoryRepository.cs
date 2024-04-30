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
            Console.WriteLine("кропка   9");
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveCategory, content);

            if (response.IsSuccessStatusCode)
            {
                string categoryJSON = await response.Content.ReadAsStringAsync();
                Category userCategory = JsonConvert.DeserializeObject<Category>(categoryJSON);
                Console.WriteLine("кропка   10");
                return userCategory;
            }
            else
            {
                Console.WriteLine("кропка   11");
                return null;
            }
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
                    Console.WriteLine("кропка   12");
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
                else
                {
                    Console.WriteLine("кропка   13");
                    return null;
                }
            }
            catch (ArgumentException)
            {

            }
            return userCategories;
        }
    }
}
