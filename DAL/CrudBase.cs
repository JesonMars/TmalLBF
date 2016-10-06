using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using DALInterface;
using Entity;
using Helper;

namespace DAL
{
    public class CrudBase<TU> where TU:BaseEntity,new()
    {

        public T Insert<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll(TU entity)
        {
            var type = typeof(TU);
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var result = DalAccessHelper.ExecuteNonQuery(string.Format("delete from {0}", table.ToLower()), null);
            return result;
        }

        public bool Update<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public T Select<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> SelectList<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public int Insert<T>(List<T> entitList)
        {
            throw new NotImplementedException();
        }


        public bool TruncateTable<T>()
        {
            var type = typeof (T);
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length,suffix.Length);
            var result = DalAccessHelper.ExecuteNonQuery(string.Format("delete from {0}",table.ToLower()),null);
            DalAccessHelper.ExecuteNonQuery(string.Format("alter table {0} alter column id counter(1,1)", table), null);
            return result>=0;
        }

        public int Insert(TU entity)
        {
            var type = typeof(TU);
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var properties=type.GetProperties();
            StringBuilder sqlBuilder=new StringBuilder();
            StringBuilder sqlValue=new StringBuilder();
            sqlBuilder.Append(string.Format("insert into {0}(", table.ToLower()));
            sqlValue.Append("Values(");
            foreach (var propertyInfo in properties)
            {
                if (propertyInfo.Name.ToLower() != "id")
                {
                    sqlBuilder.Append(string.Format("{0},", propertyInfo.Name.ToLower()));
                    sqlValue.Append(string.Format("'{0}',", propertyInfo.GetValue(entity, null)));
                }
            }
            sqlBuilder.Remove(sqlBuilder.Length-1,1).Append(")");
            sqlValue.Remove(sqlValue.Length - 1, 1).Append(")");
            var sql = string.Format("{0} {1}", sqlBuilder, sqlValue);
            var result = DalAccessHelper.ExecuteNonQuery(sql, null);
            return result;
        }

        public bool Delete(TU entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TU entity)
        {
            throw new NotImplementedException();
        }

        public TU Select(TU entity)
        {
            throw new NotImplementedException();
        }

        public List<TU> SelectList(TU entity)
        {
            throw new NotImplementedException();
        }

        public bool TruncateTable()
        {
            throw new NotImplementedException();
        }

        public int Insert(List<TU> entitList)
        {
            throw new NotImplementedException();
        }

        public TU SelectLast()
        {
            var type = typeof(TU);
            var result = new TU();
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var ds = DalAccessHelper.ExecuteDataSet(string.Format("select top 1 * from {0} order by id desc", table.ToLower()), null);
            if (ds != null && ds.Tables.Count > 0)
            {
                var properties = result.GetType().GetProperties();
                var row = ds.Tables[0].Rows[0];
                if (row != null)
                {
                    foreach (var propertyInfo in properties)
                    {
                        var value = row[propertyInfo.Name];
                        propertyInfo.SetValue(result, value, null);
                    }
                }
            }
            return result;
        }

        public T SelectLast<T>() where T:new()
        {
            var type = typeof(T);
            var result=new T();
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var ds = DalAccessHelper.ExecuteDataSet(string.Format("select top 1 * from {0} order by id desc", table.ToLower()), null);
            if (ds!=null && ds.Tables.Count>0)
            {
                var properties = result.GetType().GetProperties();
                var row = ds.Tables[0].Rows[0];
                if (row != null)
                {
                    foreach (var propertyInfo in properties)
                    {
                        var value = row[propertyInfo.Name];
                        propertyInfo.SetValue(result,value,null);
                    }
                }
            }
            return result;
        }
    }
}
