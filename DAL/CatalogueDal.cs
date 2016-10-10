using System;
using System.Collections.Generic;
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
    }
}
