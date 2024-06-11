using FinanceApp.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace FinanceApplication.core.Operations
{
    public class OperationRepository
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public async static Task<Operation> SaveOperation(Operation newOperation)
        {
            string OperationJson = JsonConvert.SerializeObject(newOperation);
            var content = new StringContent(OperationJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveOperation, content);
            Console.WriteLine("кропка   14");
            if (response.IsSuccessStatusCode)
            {
                string OperationsJson = await response.Content.ReadAsStringAsync();
                Operation userOperation = JsonConvert.DeserializeObject<Operation>(OperationsJson);
                return userOperation;
            }
            else
            {
                Console.WriteLine("кропка   15");
                return null;
            }
        }
        public async static Task<List<Operation>> GetOperations(int userId)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>{
                {"id", userId.ToString()}};
            Console.WriteLine("кропка   16");
            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetOperations, form);
            if (response.IsSuccessStatusCode)
            {
                string OperationsJson = await response.Content.ReadAsStringAsync();
                List<Operation> userOperations = JsonConvert.DeserializeObject<List<Operation>>(OperationsJson);
                Console.WriteLine("кропка   17");
                return userOperations;
            }
            else
            {
                Console.WriteLine("кропка   18");
                return null;
            }
        }
    }
}
