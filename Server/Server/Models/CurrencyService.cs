
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Server.Models
{
    public class CurrencyService : BackgroundService
    {
        private readonly IMemoryCache memoryCache;

        public CurrencyService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("ru_Ru");

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                XDocument xml = XDocument.Load("www.cbr.ru/scripts/XML_daily.asp");

                CurrencyConverter currencyConverter = new CurrencyConverter();
                currencyConverter.USD = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x=>x.Element("NumCode").Value=="840").Elements("Value").FirstOrDefault().Value);
                currencyConverter.EUR = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x=>x.Element("NumCode").Value=="978").Elements("Value").FirstOrDefault().Value);
                currencyConverter.UAH = Convert.ToDecimal(xml.Elements("ValCurs").Elements("Valute").FirstOrDefault(x=>x.Element("NumCode").Value=="980").Elements("Value").FirstOrDefault().Value);

            }
        }
    }
}
