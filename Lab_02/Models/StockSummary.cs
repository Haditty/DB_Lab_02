using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Models
{
    public class StockSummary
    {
        public long ISBN { get; set; }
        public string Title { get; set; }
        public double? Price { get; set; }
        public string Publisher { get; set; }
        public int? Stock { get; set; }
    }
}
