using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;
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

        public List<TU> SelectAll()
        {
            var type = typeof(TU);
            var result = new List<TU>();
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var ds = DalAccessHelper.ExecuteDataSet(string.Format("select * from {0} order by id desc", table.ToLower()), null);
            result = FillObjects<TU>(ds);
            return result;
        }

        public List<T> SelelctAll<T>()  where T:BaseEntity,new()
        {
            var type = typeof(T);
            var result = new List<T>();
            var table = type.Name;
            var suffix = ConfigHelper.GetEntitySuffix();
            table = table.Remove(table.Length - suffix.Length, suffix.Length);
            var ds = DalAccessHelper.ExecuteDataSet(string.Format("select * from {0} order by id desc", table.ToLower()), null);
            result = FillObjects<T>(ds);
            return result;
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
            result=FillObject<TU>(ds);
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
            result = FillObject<T>(ds);
            return result;
        }

        private List<T> FillObjects<T>(DataSet ds) where T:new()
        {
            var result=new List<T>();

            if (ds == null && ds.Tables.Count <= 0)
            {
                return result;
            }
            var rows = ds.Tables[0].Rows;
            if (rows == null && rows.Count <= 0)
            {
                return result;
            }
            foreach (DataRow row in rows)
            {
                var tu = new T();
                var properties = tu.GetType().GetProperties();
                foreach (var propertyInfo in properties)
                {
                    var value = row[propertyInfo.Name];
                    if (DBNull.Value.Equals(value))
                    {
                        continue;
                    }
                    var set = TypeHelper.ConvertObject(value,propertyInfo.PropertyType);
                    propertyInfo.SetValue(tu,set, null);
                }
                result.Add(tu);
            }
            return result;
        }

        private T FillObject<T>(DataSet ds) where T : new()
        {
            var result = new T();
            if (ds == null && ds.Tables.Count <= 0)
            {
                return result;
            }
            var rows = ds.Tables[0].Rows;
            if (rows == null && rows.Count <= 0)
            {
                return result;
            }
            var row = rows[0];
            var properties = result.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                var value = row[propertyInfo.Name];
                if (DBNull.Value.Equals(value))
                {
                    continue;
                }
                var set = TypeHelper.ConvertObject(value,propertyInfo.PropertyType);
                propertyInfo.SetValue(result, set, null);
            }
            return result;
        } 
    }
}
