namespace FinanceApplication.core.modelsForConverter
{
    public class Currency
    {
        private double rateOfCurrency;

        private double GetRateFromAPI(string Currency) 
        {
            return 3.4;
        }

        public Currency(string Currency) 
        {
            rateOfCurrency = GetRateFromAPI(Currency);
        }

       
    }
}
