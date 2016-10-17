using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.DestMake;
using BusinessInterface;
using Helper;
using Microsoft.Office.Interop.Excel;

namespace Business
{
    public class MakeDestBusiness:BaseBusiness,IMakeDestBusiness
    {
        public bool Make(Entity.MakeDestEntity entity)
        {
            var csvBusi = new MakeCsvBusiness();
            var result = true;
            try
            {
                csvBusi.Init(entity);

                if (entity.IsMakeCsv)
                {
                    csvBusi.Make(entity);
                }
                if (entity.IsMakeXlsx)
                {
                    var xlsxBusi = new MakeXlsxBusiness();
                    xlsxBusi.DataList = csvBusi.DataList;
                    xlsxBusi.FoldPath = csvBusi.FoldPath;
                    xlsxBusi.Make(entity);
                }
                if (entity.IsMakeXls)
                {
                    var xlsBusi = new MakeXlsBusiness();
                    xlsBusi.DataList = csvBusi.DataList;
                    xlsBusi.FoldPath = csvBusi.FoldPath;
                    xlsBusi.Make(entity);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log("make dest error", ex, LogHelper.LogType.Fatal);
                result= false;
            }
            
            return result;
        }

    }
}
