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
                sqlBuilder=string.Format(@"insert into cities(pc,pe,cityc,citye) values('{0}','{1}','{2}','{3}');", citiesEntity.Pc,citiesEntity.Pe,citiesEntity.Cityc,citiesEntity.Citye);
                DalAccessHelper.ExecuteNonQuery(sqlBuilder.ToString(), null);
                result += 1;
            }
            
            
            return result;
        }
    }
}
