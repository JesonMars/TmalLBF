using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace Helper
{
    public class ExcelHelper:IDisposable
    {
        private Application Application { get; set; }
        private Workbook Workbook { get; set; }
        private Sheets Sheets { get; set; }

        public ExcelHelper(){}

        public ExcelHelper(string filePath)
        {
            Application = new Application();
            Workbook = this.Application.Workbooks.Open(filePath);
            Sheets = this.Workbook == null ? null : this.Workbook.Sheets;
        }

        public List<List<string>> GetAllSheetData()
        {
            var dt = new List<List<string>>();
            if (Sheets != null)
            {
                foreach (Worksheet sheet in Sheets)
                {
                    foreach (Range row in sheet.UsedRange.Rows)
                    {
                        List<string> strs = new List<string>();
                        foreach (Range cell in row.Columns)
                        {
                            strs.Add(cell.Value != null ? cell.Value[Type.Missing].ToString() : "");
                        }
                        dt.Add(strs);
                    }
                }
            }
            return dt;
        }

        public List<List<string>> GetDataBySheetName(object sheetName)
        {
            var dt = new List<List<string>>();
            if (Sheets != null)
            {
                var sheet = (Worksheet)Sheets[sheetName];
                if (sheet != null)
                {
                    foreach (Range row in sheet.UsedRange.Rows)
                    {
                        List<string> strs=new List<string>();
                        foreach (Range cell in row.Columns)
                        {
                            strs.Add(cell.Value!=null?cell.Value[Type.Missing].ToString():"");
                        }
                        dt.Add(strs);
                    }
                }
            }
            return dt;
        }

        public List<Dictionary<string,string>> GetDicsExceptHeader(object sheetName)
        {
            var dt = new List<Dictionary<string, string>>();
            if (Sheets != null)
            {
                var sheet = (Worksheet)Sheets[sheetName];
                if (sheet != null)
                {
                    //get the excel headers
                    var headers =new string[sheet.UsedRange.Columns.Count];
                    for (int i = 1; i<=sheet.UsedRange.Columns.Count; i++)
                    {
                        var text = ((Range)sheet.UsedRange.Cells[1, i]);
                        string head = (text != null && text.Text != null)?text.Text.ToString():"";
                        headers[i-1]=head;
                    }

                    try
                    {
                        for (int i = 2; i <= sheet.UsedRange.Rows.Count; i++)
                        {
                            var dics = new Dictionary<string, string>();
                            for (int j = 1; j <= sheet.UsedRange.Columns.Count; j++)
                            {
                                var text = ((Range)sheet.UsedRange.Cells[1, i]);
                                string head = (text != null && text.Text != null) ? text.Text.ToString() : "";
                                dics.Add(headers[j - 1], head);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return dt;
        }
    
        public List<Dictionary<string,string>> GetDicsExceptHeader(object sheetName,params string[] headers)
        {
            var dt = new List<Dictionary<string, string>>();
            if (Sheets != null)
            {
                var sheet = (Worksheet)Sheets[sheetName];
                if (sheet != null)
                {
                    try
                    {
                        for (int i = 2; i <= sheet.UsedRange.Rows.Count; i++)
                        {
                            var dics = new Dictionary<string, string>();
                            for (int j = 1; j <= sheet.UsedRange.Columns.Count; j++)
                            {
                                var text = ((Range)sheet.UsedRange.Cells[1, i]);
                                string head = (text != null && text.Text != null) ? text.Text.ToString() : "";
                                dics.Add(headers[j - 1], head);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// wether the filepath is excel doc,true means it's excel doc,false means it's not excel
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>bool</returns>
        public static bool IsExcel(string filePath)
        {
            var extension = FileHelper.GetFileExtension(filePath);
            var shouldExtension = ConfigurationSettings.AppSettings.Get("exceltype");

            if (string.IsNullOrEmpty(extension) || !shouldExtension.Contains(extension))
            {
                return false;
            }
            return true;
        }

        ~ExcelHelper()
        {
            
        }

        public void Dispose()
        {
            if(Workbook!=null)
                Workbook.Close();

            Sheets = null;
            Workbook = null;
            Application = null;
        }
    }

    
}
