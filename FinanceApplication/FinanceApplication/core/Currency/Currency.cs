using Org.Apache.Http.Cookies;
using System;
namespace FinanceApplication.core.Currency
{
    public class Currency
    {
        public decimal USD_in { get; set; }
        public decimal EUR_in { get; set; }
        public decimal RUB_in { get; set; }
        public decimal PLN_in { get; set; }
        public decimal CNY_in { get; set; }
        public decimal ToUSD(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum;
                case 2: return sum * (USD_in / EUR_in);
                case 3: return sum * (USD_in / (RUB_in / 100));
                case 4: return sum * (USD_in / PLN_in * 10);
                case 5: return sum * (USD_in / CNY_in * 10);
                case 6: return sum * USD_in;
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public decimal ToEUR(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum * (EUR_in / USD_in);
                case 2: return sum;
                case 3: return sum * (EUR_in / (RUB_in / 100));
                case 4: return sum * (EUR_in / PLN_in * 10);
                case 5: return sum * (EUR_in / CNY_in * 10);
                case 6: return sum * EUR_in;
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public decimal ToRUB(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum * ((RUB_in / 100) / USD_in);
                case 2: return sum * ((RUB_in / 100) / EUR_in);
                case 3: return sum;
                case 4: return sum * ((RUB_in / 100) / PLN_in * 10);
                case 5: return sum * ((RUB_in / 100) / CNY_in * 10);
                case 6: return sum * (RUB_in / 100);
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public decimal ToBYN(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum * USD_in;
                case 2: return sum * (USD_in / EUR_in);
                case 3: return sum * (USD_in / (RUB_in / 100));
                case 4: return sum * (USD_in / PLN_in * 10);
                case 5: return sum * (USD_in / CNY_in * 10);
                case 6: return sum * (USD_in / EUR_in);
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public decimal ToPLN(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum * (PLN_in / USD_in * 0.1m);
                case 2: return sum * (PLN_in / EUR_in * 0.1m);
                case 3: return sum * (PLN_in / (RUB_in / 100) * 0.1m);
                case 4: return sum;
                case 5: return sum * (PLN_in / CNY_in * 10);
                case 6: return sum * (PLN_in / 10);
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public decimal ToCNY(int currency, decimal sum)
        {
            switch (currency)
            {
                case 1: return sum * (CNY_in / USD_in * 0.1m);
                case 2: return sum * (CNY_in / EUR_in * 0.1m);
                case 3: return sum * (CNY_in / (RUB_in / 100) * 0.1m);
                case 4: return sum * (CNY_in / PLN_in * 0.1m);
                case 5: return sum;
                case 6: return sum * (CNY_in / 10);
                default: throw new ArgumentException("Invalid currency code.");
            }
        }
        public override string ToString()
        {
            return $"USD_in_BYN {USD_in}  EUR_in_BYN {EUR_in} RUB_in_BYN {RUB_in} PLN_in_BYN {PLN_in}";
        }
    }
}
