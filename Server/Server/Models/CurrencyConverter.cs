namespace Server.Models
{
    public class CurrencyConverter
    {
        
        public decimal USD { get; set; }
        public decimal ConvertToUSD (decimal priceRUB) => priceRUB / USD;

        public decimal EUR { get; set; }
        public decimal ConvertToEUR (decimal priceRUB) => priceRUB / EUR;

        public decimal UAH { get; set; }
        public decimal ConvertToUAH (decimal priceRUB) => priceRUB / UAH / 10;




    }
}
