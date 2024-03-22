using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.classes.Wallets
{
    public static class WalletRepository
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async static Task<bool> SaveWallet(Wallet newWallet)
        {
            string walletJson = JsonConvert.SerializeObject(newWallet);
            var content = new StringContent(walletJson, Encoding.UTF8, "application/json");

            Console.WriteLine(newWallet);
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveWallet, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.IsSuccessStatusCode);
                return true;
            }
            else return false;
        }

        public async static Task<List<Wallet>> GetWallets(int userId)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>
        {
            {"id", userId.ToString()}
        };

            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetWallets, form);

            if (response.IsSuccessStatusCode)
            {
                string walletsJson = await response.Content.ReadAsStringAsync();
                List<Wallet> userWallets = JsonConvert.DeserializeObject<List<Wallet>>(walletsJson);
                foreach (Wallet wallet in userWallets)
                {
                    Console.WriteLine(wallet);
                }
                return userWallets;
            }
            else
            {
                return null;
            }
        }
    }

}
