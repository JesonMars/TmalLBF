using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using DALInterface;
using Entity;
using Helper;

namespace DAL
{
    public class CityDal:CrudBase<CitiesEntity>,ICityDal
    {
        public int Insert(List<CitiesEntity> cities)
        {
            var result = 0;
            string sqlBuilder = "";
            foreach (var citiesEntity in cities)
            {
                sqlBuilder=string.Format(@"insert into cities(pc,pe,cityc,citye,postcode) values(@pc,@pe,@cityc,@citye,@post);");
                var param=new List<OleDbParameter>();
                param.Add(new OleDbParameter("@pc", citiesEntity.Pc));
                param.Add(new OleDbParameter("@pe", citiesEntity.Pe));
                param.Add(new OleDbParameter("@cityc", citiesEntity.Cityc));
                param.Add(new OleDbParameter("@citye", citiesEntity.Citye));
                param.Add(new OleDbParameter("@post", citiesEntity.PostCode));
                DalAccessHelper.ExecuteNonQuery(sqlBuilder.ToString(), param);
                result += 1;
            }
            
            
            return result;
        }
    }
}
