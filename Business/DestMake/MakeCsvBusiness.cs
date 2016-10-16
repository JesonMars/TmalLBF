using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Helper;
using Microsoft.Office.Interop.Excel;

namespace Business.DestMake
{
    public class MakeCsvBusiness:MakeBaseBusiness
    {
        public MakeCsvBusiness():base()
        {
            
        }
        public override string CreateFile()
        {
            var excelHelper = new ExcelHelper();
            var filename = string.Format(@"{0}\{1}.{2}",FoldPath, ConfigHelper.GetDestFileName(),Extension);
            excelHelper.ExportExcel(filename, DataList, "Expected file order",XlFileFormat.xlCSV);
            return filename;
        }

        public override string Extension
        {
            get { return "csv"; }
        }
    }
}
