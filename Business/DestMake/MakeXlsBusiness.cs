using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DestMake
{
    public class MakeXlsBusiness : MakeBaseBusiness
    {
        public MakeXlsBusiness():base(){}
        public override string CreateFile()
        {
            var result="xls";
            return result;
        }

        public override string Extension
        {
            get { return "xls"; }
        }
    }
}
