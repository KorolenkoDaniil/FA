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
            HttpResponseMessage response = await httpClient.PostAsync(Links.SaveWallet, content);
            if (response.IsSuccessStatusCode)
            {
                string walletJSON = await response.Content.ReadAsStringAsync();
                Wallet userWallet = JsonConvert.DeserializeObject<Wallet>(walletJSON);
                return userWallet;
            }
            else
            {
                return null;
            }
        }
        public async static Task<bool> DeleteWallet(Wallet newWallet)
        {
            string walletJson = JsonConvert.SerializeObject(newWallet);
            var content = new StringContent(walletJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(Links.DeleteWallet, content);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        public async static Task<List<Wallet>> GetWallets(int userId)
        {
            Console.WriteLine("кропка   21");
            Dictionary<string, string> userData = new Dictionary<string, string>{
            {"id", userId.ToString()} };
            FormUrlEncodedContent form = new FormUrlEncodedContent(userData);
            HttpResponseMessage response = await httpClient.PostAsync(Links.GetWallets, form);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("кропка   22");
                string walletsJson = await response.Content.ReadAsStringAsync();
                List<Wallet> userWallets = JsonConvert.DeserializeObject<List<Wallet>>(walletsJson);
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