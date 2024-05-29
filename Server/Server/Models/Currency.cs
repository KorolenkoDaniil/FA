namespace Server.Models
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

        public override string ToString()
        {
            return $"USD_in {USD_in}  EUR_in {EUR_in}  RUB_in {RUB_in}" +
                $"PLN_in{PLN_in}";
        }


    }
}
