using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DestMake
{
    public class MakeXlsxBusiness:MakeBaseBusiness
    {
        public MakeXlsxBusiness():base()
        {
            
        }
        public override string CreateFile()
        {
            var result = "xlsx";
            return result;
        }

        public override string Extension
        {
            get { return "xlsx"; }
        }
    }
}
