﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using Microsoft.Office.Interop.Excel;

namespace Business.DestMake
{
    public class MakeXlsBusiness : MakeBaseBusiness
    {
        public MakeXlsBusiness():base(){}

        public override string CreateFile()
        {
            var excelHelper = new ExcelHelper();
            var filename = string.Format(@"{0}\{1}.{2}", FoldPath, ConfigHelper.GetDestFileName(), Extension);
            excelHelper.ExportExcel(filename, new List<List<string>>(), "Expected file order", XlFileFormat.xlExcel8);
            return filename;
        }

        public override string Extension
        {
            get { return "xls"; }
        }
    }
}
