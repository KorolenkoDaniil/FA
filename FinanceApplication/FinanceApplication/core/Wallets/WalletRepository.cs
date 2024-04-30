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

        public async static Task<Wallet> SaveWallet(Wallet newWallet)
        {
            string walletJson = JsonConvert.SerializeObject(newWallet);
            var content = new StringContent(walletJson, Encoding.UTF8, "application/json");

            //Console.WriteLine(newWallet);
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveWallet, content);
            Console.WriteLine("кропка   19");
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine(response.IsSuccessStatusCode);
                string walletJSON = await response.Content.ReadAsStringAsync();
                Wallet userWallet = JsonConvert.DeserializeObject<Wallet>(walletJSON);
                return userWallet;
            }
            else
            {
                Console.WriteLine("кропка   20");
                return null;
            }
        }

        public async static Task<List<Wallet>> GetWallets(int userId)
        {
            Console.WriteLine("кропка   21");
            Dictionary<string, string> userData = new Dictionary<string, string>
        {
            {"id", userId.ToString()}
        };

            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetWallets, form);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("кропка   22");
                string walletsJson = await response.Content.ReadAsStringAsync();
                List<Wallet> userWallets = JsonConvert.DeserializeObject<List<Wallet>>(walletsJson);
                //Console.WriteLine("----------- кошелек");
                //foreach (Wallet wallet in userWallets)
                //{
                    //Console.WriteLine(wallet);
                //}
                //Console.WriteLine("----------- кошелек");
                return userWallets;
            }
            else
            {
                Console.WriteLine("кропка   23");
                return null;
            }
        }
    }

}
