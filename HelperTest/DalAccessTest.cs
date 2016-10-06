using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelperTest
{
    [TestClass]
    public class DalAccessTest
    {
        [TestMethod]
        public void TestSelect()
        {
            var param = new OleDbParameter("@id",2);
            var parameters=new List<OleDbParameter>();
            parameters.Add(param);
            var result=DalAccessHelper.ExecuteDataSet("select * from test where id=@id",parameters);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result,typeof (DataSet));
            Assert.IsTrue(result.Tables.Count>0);

            foreach (DataTable table in result.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (var o in row.ItemArray)
                    {
                        Console.Write(o.ToString()+" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void TestInsert()
        {
            var parameters=new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@name",DateTime.Now.ToString("yyyy-MM-dd")));
            parameters.Add(new OleDbParameter("@sex","男"));
            var result = DalAccessHelper.ExecuteDataSet("insert into test(name,sex) values(@name,@sex)", parameters);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@name", DateTime.Now.ToString("yyyyMMdd")));
            var result = DalAccessHelper.ExecuteDataSet("update test set name=@name where id=2", parameters);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDelete()
        {
            var parameters = new List<OleDbParameter>();
            parameters.Add(new OleDbParameter("@name", DateTime.Now.ToString("yyyy-MM-dd")));
            var result = DalAccessHelper.ExecuteDataSet("delete from test where name=@name", parameters);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestTable()
        {
            var result = DalAccessHelper.ExecuteDataSet("create table test1(name varchar(10),sex varchar(10));", null);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DataSet));
        }

        [TestMethod]
        public void TestDrop()
        {
            var result = DalAccessHelper.ExecuteDataSet("drop table test1;", null);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DataSet));
        }

        [TestMethod]
        public void TestTruncate()
        {
            var result = DalAccessHelper.ExecuteNonQuery("delete from test;", null);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DataSet));
        }

        
    }
}
