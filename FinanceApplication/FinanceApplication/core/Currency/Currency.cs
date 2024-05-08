namespace FinanceApplication.core.Currency
{
    public class Currency
    {
        public decimal USD_in { get; set; }
        public decimal EUR_in { get; set; }
        public decimal RUB_in { get; set; }
        public decimal GBP_in { get; set; }
        public decimal PLN_in { get; set; }
        public decimal USD_EUR_in { get; set; }
        public decimal USD_RUB_in { get; set; }
        public decimal RUB_EUR_in { get; set; }
        public decimal CNY_in { get; set; }
        public decimal CNY_USD_in { get; set; }

        public override string ToString()
        {
            return $"USD_in {USD_in}  EUR_in {EUR_in}  RUB_in {RUB_in}  GBP_in {GBP_in} " +
                $"PLN_in{PLN_in}  USD_EUR_in {USD_EUR_in}  USD_RUB_in {USD_RUB_in}";
        }


    }
}
