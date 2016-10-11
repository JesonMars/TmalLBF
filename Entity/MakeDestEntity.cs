using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class MakeDestEntity
    {
        public string OrderListFile { get; set; }
        public string OrderDetailListFile { get; set; }
        public string DestFolder { get; set; }
        public bool IsPushToFtp { get; set; }
        public bool IsMakeXls { get; set; }
        public bool IsMakeCsv { get; set; }
        public bool IsMakeXlsx { get; set; }
    }
}
