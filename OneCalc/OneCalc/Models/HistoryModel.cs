using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCalc.Models
{
    class HistoryModel
    {
        public string Calculation { get; set; }
        public string Result  { get; set; }
        public DateTime CalcDateTime  { get; set; }
    }
}
