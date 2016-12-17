using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace Entity
{
    /// <summary>
    /// excel颜色单元格
    /// </summary>
    public class ExcelColorEntity
    {
        /// <summary>
        /// 单元格所在的第几行，从1开始
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// 单元格所在第几列，从1开始
        /// </summary>
        public int ColumnIndex { get; set; }
        /// <summary>
        /// 该单元格的颜色
        /// </summary>
        public XlRgbColor XlRgbColor { get; set; }
    }
}
