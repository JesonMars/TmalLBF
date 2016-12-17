using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.DestMake;
using BusinessInterface;
using Helper;
using log4net.Repository.Hierarchy;
using Microsoft.Office.Interop.Excel;

namespace Business
{
    public class MakeDestBusiness:BaseBusiness,IMakeDestBusiness
    {
        public string Make(Entity.MakeDestEntity entity)
        {
            var csvBusi = new MakeCsvBusiness();
            var result = new StringBuilder();
            try
            {
                result.Append(csvBusi.Init(entity));

                if (entity.IsMakeCsv)
                {
                    csvBusi.Make(entity);
                }
                if (entity.IsMakeXlsx)
                {
                    var xlsxBusi = new MakeXlsxBusiness();
                    xlsxBusi.DataList = csvBusi.DataList;
                    xlsxBusi.FoldPath = csvBusi.FoldPath;
                    xlsxBusi.ExcelColorEntities = csvBusi.ExcelColorEntities;
                    xlsxBusi.Make(entity);
                }
                if (entity.IsMakeXls)
                {
                    var xlsBusi = new MakeXlsBusiness();
                    xlsBusi.DataList = csvBusi.DataList;
                    xlsBusi.FoldPath = csvBusi.FoldPath;
                    xlsBusi.ExcelColorEntities = csvBusi.ExcelColorEntities;
                    xlsBusi.Make(entity);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("make dest error", ex, LogHelper.LogType.Error);
                result.AppendLine(ex.Message);
            }
            
            return result.ToString();
        }

    }
}
