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

        public async static Task<bool> SaveOperation(Operation newOperation)
        {
            string OperationJson = JsonConvert.SerializeObject(newOperation);
            var content = new StringContent(OperationJson, Encoding.UTF8, "application/json");

            Console.WriteLine(newOperation);
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveOperation, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
                return true;
            }
            else return false;
        }

        public async static Task<List<Operation>> GetOperations(int userId)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>
            {
                {"id", userId.ToString()}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetOperations, form);

            if (response.IsSuccessStatusCode)
            {
                string OperationsJson = await response.Content.ReadAsStringAsync();
                List<Operation> userOperations = JsonConvert.DeserializeObject<List<Operation>>(OperationsJson);
                Console.WriteLine("----------- операция");
                foreach (Operation Operation in userOperations)
                {
                    Console.WriteLine(Operation);
                }
                Console.WriteLine("----------- операция");

                return userOperations;
            }
            else
            {
                return null;
            }
        }
    }
}
