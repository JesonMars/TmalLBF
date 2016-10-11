using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.DestMake;
using BusinessInterface;

namespace Business
{
    public class MakeDestBusiness:BaseBusiness,IMakeDestBusiness
    {
        public bool Make(Entity.MakeDestEntity entity)
        {
            var csvBusi = new MakeCsvBusiness();
            csvBusi.Init(entity);

            if (entity.IsMakeCsv)
            {
                csvBusi.Make(entity);
            }
            if (entity.IsMakeXlsx)
            {
                var xlsxBusi = new MakeXlsxBusiness();
                xlsxBusi.Application = csvBusi.Application;
                xlsxBusi.DataList = csvBusi.DataList;
                xlsxBusi.Make(entity);
            }
            if (entity.IsMakeXls)
            {
                var xlsBusi = new MakeXlsBusiness();
                xlsBusi.Application = csvBusi.Application;
                xlsBusi.DataList = csvBusi.DataList;
                xlsBusi.Make(entity);
            }
            return true;
        }

    }
}
