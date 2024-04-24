using FinanceApplication.core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceApplication.core
{
    public class OperationsDays
    {
        public DateTime date { get; set; }
        public string Day { get => date.Day.ToString(); }
        public string Month { get => date.ToString("MMMM"); }
        public string Year { get => date.ToString("yyyy"); }
        public string WeekDay { get => date.ToString("yyyy"); }
        public decimal profitSum { get; set; }
        public decimal expenses { get; set; }
        public List<OperationResult> Operations { get; set; }


        public OperationsDays(DateTime date, List<OperationResult> operations)
        {
            this.date = date;
            Operations = operations;
            profitSum = operations.Where(o => o.Profit).Sum(o => o.Sum);
            expenses = operations.Where(o => !o.Profit).Sum(o => o.Sum);
            Console.WriteLine(profitSum + $"доходы дня {date}");
            Console.WriteLine(expenses + $"расходы дня {date}");
        }
    }
}
