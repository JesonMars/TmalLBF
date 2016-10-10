using System;
using System.Collections.Generic;
using System.Text;
using DALInterface;
using Entity;
using Helper;

namespace DAL
{
    public class ArcancilDal:CrudBase<ArcancilEntity>,IArcancilDal
    {

        public int Insert(List<ArcancilEntity> arcancils)
        {
            var result = 0;
            string sqlBuilder = "";
            foreach (var arcancil in arcancils)
            {
                sqlBuilder = string.Format(@"insert into arcancil(company,brand,reference,produits) values('{0}','{1}','{2}','{3}');",arcancil.Company,arcancil.Brand,arcancil.Reference,arcancil.Produits);
                DalAccessHelper.ExecuteNonQuery(sqlBuilder.ToString(), null);
                result += 1;
            }
            return result;
        }
    }
}
