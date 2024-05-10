using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApplication.core.Currency
{
    public class CurrencyConverter
    {

        //public decimal ConvertToUSD(decimal priceRUB) => priceRUB / USD;

        public decimal EUR { get; set; }
        public decimal ConvertToEUR(decimal priceRUB) => priceRUB / EUR;

        public decimal UAH { get; set; }
        public decimal ConvertToUAH(decimal priceRUB) => priceRUB / UAH / 10;

    }
}
