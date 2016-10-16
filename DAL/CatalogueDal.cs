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
                                    ) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}');",
                                    catalogue.FCompany,catalogue.EBrand,catalogue.CBrand,catalogue.SubCategory,catalogue.SecondCategory,
                                    catalogue.TertiaryCategory,catalogue.TmallFees,catalogue.MainNum,catalogue.SubNum,catalogue.EFullProductName,catalogue.CFullProductName,
                                    catalogue.EColor,catalogue.CColor,catalogue.BarEnCode,catalogue.ProductRef,catalogue.CustomsCodification,catalogue.SLength,catalogue.SWidth,
                                    catalogue.SHauteur,catalogue.WeightGr,catalogue.WeightKg,catalogue.EuMiniSalePrice,catalogue.RmbMiniSalePrice,catalogue.EuMarkupSalePrice,catalogue.RmbMarkupSalePrice,
                                    catalogue.EuShippingCost,catalogue.RmbShippingCost,catalogue.EuSalePrice,catalogue.RmbSalePrice,catalogue.Stocks);
                DalAccessHelper.ExecuteNonQuery(sqlBuilder.ToString(), null);
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
