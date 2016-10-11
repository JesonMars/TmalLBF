using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business.DestMake
{
    public class MakeCsvBusiness:MakeBaseBusiness
    {
        public MakeCsvBusiness():base()
        {
            
        }
        public override string CreateFile()
        {
            var result = "csv";
            return result;
        }

        public override string Extension
        {
            get { return "csv"; }
        }
    }
}
