using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using Microsoft.Office.Interop.Excel;

namespace Business.DestMake
{
    public class MakeXlsxBusiness:MakeBaseBusiness
    {
        public MakeXlsxBusiness():base()
        {
            
        }
        public override string CreateFile()
        {
            var excelHelper = new ExcelHelper();
            var filename = string.Format(@"{0}\{1}.{2}", FoldPath, ConfigHelper.GetDestFileName(), Extension);
            excelHelper.ExportExcel(filename, new List<List<string>>(), "Expected file order", XlFileFormat.xlOpenXMLWorkbook);
            return filename;
        }

        public override string Extension
        {
            get { return "xlsx"; }
        }
    }
}
