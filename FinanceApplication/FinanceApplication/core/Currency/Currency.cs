
using static System.Math;

namespace FinanceApplication.core.Currency
{
    public class Currency
    {

        public decimal USD_in { get; set; }
        public decimal EUR_in { get; set; }
        public decimal RUB_in { get; set; }
        public decimal PLN_in { get; set; }
        public decimal CNY_in { get; set; }
        public decimal USD_out { get; set; }
        public decimal EUR_out { get; set; }
        public decimal RUB_out { get; set; }
        public decimal PLN_out { get; set; }
        public decimal CNY_out { get; set; }

        public decimal ConvertEURtoUSD(decimal sumInEUR) => Round(sumInEUR * EUR_in / USD_in, 3);
        public decimal ConvertUSDtoEUR(decimal sumInUSD) => Round(sumInUSD * USD_in / EUR_in, 3);

        public decimal ConvertRUBtoUSD(decimal sumInRUB) => Round(sumInRUB * RUB_in / USD_in, 3);
        public decimal ConvertUSDtoRUB(decimal sumInUSD) => Round(sumInUSD * USD_in / RUB_in * 100, 3);
        public decimal ConvertPLNtoUSD(decimal sumInPLN) => Round(sumInPLN * PLN_in / USD_in, 3);
        public decimal ConvertUSDtoPLN(decimal sumInUSD) => Round(sumInUSD * USD_in / PLN_in * 10, 3);

        public decimal ConvertCNYtoUSD(decimal sumInCNY) => Round(sumInCNY * CNY_in / USD_in, 3);
        public decimal ConvertUSDtoCNY(decimal sumInUSD) => Round(sumInUSD * USD_in / CNY_in * 10, 3);

        public decimal ConvertBYNtoUSD(decimal sumInBYN) => Round(sumInBYN / USD_in, 3);
        public decimal ConvertUSDtoBYN(decimal sumInUSD) => Round(sumInUSD * USD_in, 3);

        public override string ToString()
        {
            return $"USD_in_BYN {USD_in}  EUR_in_BYN {EUR_in}  RUB_in_BYN {RUB_in}" +
                $"PLN_in_BYN {PLN_in}";
        }
    }
}
