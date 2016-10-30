using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using DALInterface;
using Entity;
using Helper;

namespace DAL
{
    public class CatalogueDal:CrudBase<CatalogueEntity>,ICatalogueDal
    {
        public int Insert(List<CatalogueEntity> catalogueEntities)
        {
            var result = 0;
            string sqlBuilder = "";
            foreach (var catalogue in catalogueEntities)
            {
                var param=new List<OleDbParameter>();
                sqlBuilder = string.Format(@"insert into catalogue(fcompany,
                                                                ebrand,
                                                                cbrand,
                                                                subcategory,
                                                                secondcategory,
                                                                tertiarycategory,
                                                                tmallfees,
                                                                mainnum,
                                                                subnum,
                                                                efullproductname,
                                                                cfullproductname,
                                                                ecolor,
                                                                ccolor,
                                                                barencode,
                                                                productref,
                                                                customscodification,
                                                                slength,
                                                                swidth,
                                                                shauteur,
                                                                weightgr,
                                                                weightkg,
                                                                euminisaleprice,
                                                                rmbminisaleprice,
                                                                eumarkupsaleprice,
                                                                rmbmarkupsaleprice,
                                                                eushippingcost,
                                                                rmbshippingcost,
                                                                eusaleprice,
                                                                rmbsaleprice,
                                                                stocks
                                    ) values(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29);");
                param.Add(new OleDbParameter("@0",catalogue.FCompany));
                param.Add(new OleDbParameter("@1",catalogue.EBrand));
                param.Add(new OleDbParameter("@2",catalogue.CBrand));
                param.Add(new OleDbParameter("@3",catalogue.SubCategory));
                param.Add(new OleDbParameter("@4",catalogue.SecondCategory));
                param.Add(new OleDbParameter("@5",catalogue.TertiaryCategory));
                param.Add(new OleDbParameter("@6",catalogue.TmallFees));
                param.Add(new OleDbParameter("@7",catalogue.MainNum));
                param.Add(new OleDbParameter("@8",catalogue.SubNum));
                param.Add(new OleDbParameter("@9",catalogue.EFullProductName));
                param.Add(new OleDbParameter("@10",catalogue.CFullProductName));
                param.Add(new OleDbParameter("@11",catalogue.EColor));
                param.Add(new OleDbParameter("@12",catalogue.CColor));
                param.Add(new OleDbParameter("@13",catalogue.BarEnCode));
                param.Add(new OleDbParameter("@14",catalogue.ProductRef));
                param.Add(new OleDbParameter("@15",catalogue.CustomsCodification));
                param.Add(new OleDbParameter("@16",catalogue.SLength));
                param.Add(new OleDbParameter("@17",catalogue.SWidth));
                param.Add(new OleDbParameter("@18",catalogue.SHauteur));
                param.Add(new OleDbParameter("@19",catalogue.WeightGr));
                param.Add(new OleDbParameter("@20",catalogue.WeightKg));
                param.Add(new OleDbParameter("@21",catalogue.EuMiniSalePrice));
                param.Add(new OleDbParameter("@22",catalogue.RmbMiniSalePrice));
                param.Add(new OleDbParameter("@23",catalogue.EuMarkupSalePrice));
                param.Add(new OleDbParameter("@24",catalogue.RmbMarkupSalePrice));
                param.Add(new OleDbParameter("@25",catalogue.EuShippingCost));
                param.Add(new OleDbParameter("@26",catalogue.RmbShippingCost));
                param.Add(new OleDbParameter("@27",catalogue.EuSalePrice));
                param.Add(new OleDbParameter("@28",catalogue.RmbSalePrice));
                param.Add(new OleDbParameter("@29", catalogue.Stocks));
                var sql = sqlBuilder.ToString();
                DalAccessHelper.ExecuteNonQuery(sql, param);
                result += 1;
            }
            return result;
        }

        public List<CatalogueEntity> SelectList(CatalogueEntity entity)
        {
            var result=new List<CatalogueEntity>();
            var sql = "select * from catalogue where productref=@productref and ebrand=@ebrand";
            var param=new List<OleDbParameter>();
            param.Add(new OleDbParameter("@productref",entity.ProductRef));
            param.Add(new OleDbParameter("@ebrand", entity.EBrand));
            var ds=DalAccessHelper.ExecuteDataSet(sql, param);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var catalogue = FillCatalogue(row);
                    result.Add(catalogue);
                }
            }
            return result;
        }

        private CatalogueEntity FillCatalogue(DataRow row)
        {
            var catalogue=new CatalogueEntity();
            if (row != null)
            {
                catalogue.FCompany = string.IsNullOrEmpty(row[0].ToString()) ? "" : row[0].ToString();
                catalogue.EBrand = string.IsNullOrEmpty(row[1].ToString()) ? "" : row[1].ToString();
                catalogue.CBrand = string.IsNullOrEmpty(row[2].ToString()) ? "" : row[2].ToString();
                catalogue.SubCategory = string.IsNullOrEmpty(row[3].ToString()) ? "" : row[3].ToString();
                catalogue.SecondCategory = string.IsNullOrEmpty(row[4].ToString()) ? "" : row[4].ToString();
                catalogue.TertiaryCategory = string.IsNullOrEmpty(row[5].ToString()) ? "" : row[5].ToString();
                catalogue.TmallFees = string.IsNullOrEmpty(row[6].ToString()) ? 0 : decimal.Parse(row[6].ToString());
                catalogue.MainNum = string.IsNullOrEmpty(row[7].ToString()) ? 0 : decimal.Parse(row[7].ToString());
                catalogue.SubNum = string.IsNullOrEmpty(row[7].ToString()) ? 0 : decimal.Parse(row[7].ToString());
                catalogue.EFullProductName = string.IsNullOrEmpty(row[8].ToString()) ? "" : row[8].ToString();
                catalogue.CFullProductName = string.IsNullOrEmpty(row[9].ToString()) ? "" : row[9].ToString();
                catalogue.EColor = string.IsNullOrEmpty(row[10].ToString()) ? "" : row[10].ToString();
                catalogue.CColor = string.IsNullOrEmpty(row[11].ToString()) ? "" : row[11].ToString();
                catalogue.BarEnCode = string.IsNullOrEmpty(row[12].ToString()) ? "" : row[12].ToString();
                catalogue.ProductRef = string.IsNullOrEmpty(row[13].ToString()) ? "" : row[13].ToString();
                catalogue.CustomsCodification = string.IsNullOrEmpty(row[14].ToString()) ? "" : row[14].ToString();
                catalogue.SLength = string.IsNullOrEmpty(row[15].ToString()) ? 0 : decimal.Parse(row[15].ToString());
                catalogue.SWidth = string.IsNullOrEmpty(row[16].ToString()) ? 0 : decimal.Parse(row[16].ToString());
                catalogue.SHauteur = string.IsNullOrEmpty(row[17].ToString()) ? 0 : decimal.Parse(row[17].ToString());
                catalogue.WeightGr = string.IsNullOrEmpty(row[18].ToString()) ? 0 : decimal.Parse(row[18].ToString());
                catalogue.WeightKg = string.IsNullOrEmpty(row[19].ToString()) ? 0 : decimal.Parse(row[19].ToString());
                catalogue.EuMiniSalePrice = string.IsNullOrEmpty(row[20].ToString()) ? 0 : decimal.Parse(row[20].ToString());
                catalogue.RmbMiniSalePrice = string.IsNullOrEmpty(row[21].ToString()) ? 0 : decimal.Parse(row[21].ToString());
                catalogue.EuMarkupSalePrice = string.IsNullOrEmpty(row[22].ToString()) ? 0 : decimal.Parse(row[22].ToString());
                catalogue.RmbMarkupSalePrice = string.IsNullOrEmpty(row[23].ToString()) ? 0 : decimal.Parse(row[23].ToString());
                catalogue.EuShippingCost = string.IsNullOrEmpty(row[24].ToString()) ? 0 : decimal.Parse(row[24].ToString());
                catalogue.RmbShippingCost = string.IsNullOrEmpty(row[25].ToString()) ? 0 : decimal.Parse(row[25].ToString());
                catalogue.EuSalePrice = string.IsNullOrEmpty(row[26].ToString()) ? 0 : decimal.Parse(row[26].ToString());
                catalogue.RmbSalePrice = string.IsNullOrEmpty(row[27].ToString()) ? 0 : decimal.Parse(row[27].ToString());
                catalogue.Stocks = string.IsNullOrEmpty(row[28].ToString()) ? "" : row[28].ToString();
            }
            return catalogue;
        }
    }
}
