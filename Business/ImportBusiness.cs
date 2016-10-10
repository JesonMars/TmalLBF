using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessInterface;
using Component;
using DALInterface;
using Entity;
using Helper;

namespace Business
{
    public class ImportBusiness:BaseBusiness,IImportBusiness
    {
        /// <summary>
        /// import the cities data from excel file
        /// </summary>
        /// <param name="filePath">the path of the excel</param>
        /// <returns>true,import success,or false</returns>
        public bool ImportCitiesFromExcel(string filePath)
        {
            if (!File.Exists(filePath) && !ExcelHelper.IsExcel(filePath))
            {
                return false;
            }

            var excelHelper = new ExcelHelper(filePath);
            var cities=excelHelper.GetAllSheetData();

            if (cities != null && cities.Count > 0)
            {
                //first we need truncate cities table delete the old data
                var cityDal = Factory.Instance().GetService<ICityDal>();
                cityDal.TruncateTable<CitiesEntity>();
                //then add the new city data
                var newCities=new List<CitiesEntity>();
                foreach (var city in cities)
                {
                    var cityone=new CitiesEntity();
                    cityone.Pc=string.IsNullOrEmpty(city[0]) ? newCities[newCities.Count-1].Pc: city[0];
                    cityone.Pe = string.IsNullOrEmpty(city[0]) ? newCities[newCities.Count - 1].Pe : city[1];
                    cityone.Cityc=city[2];
                    cityone.Citye=city[3];
                    cityone.PostCode = city[4];
                    newCities.Add(cityone);
                }
                var result=cityDal.Insert(newCities);

                if (result != cities.Count)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// import arcancil data from excel file
        /// </summary>
        /// <param name="filePath">the path of the arcancil</param>
        /// <returns>true,import success,or false</returns>
        public bool ImportArcancilFromExcel(string filePath)
        {
            if (!File.Exists(filePath) && !ExcelHelper.IsExcel(filePath))
            {
                return false;
            }

            var excelHelper = new ExcelHelper(filePath);
            var arcancils = excelHelper.GetAllSheetData();

            if (arcancils != null && arcancils.Count > 0)
            {
                //first we need truncate cities table delete the old data
                var arcancailDal = Factory.Instance().GetService<IArcancilDal>();
                arcancailDal.TruncateTable<ArcancilEntity>();
                //then add the new city data
                var newArcancil = new List<ArcancilEntity>();
                foreach (var arcancil in arcancils)
                {
                    var arcancilOne = new ArcancilEntity();
                    arcancilOne.Company = string.IsNullOrEmpty(arcancil[0]) ? "" : arcancil[0];
                    arcancilOne.Brand = string.IsNullOrEmpty(arcancil[1]) ? "" : arcancil[1];
                    arcancilOne.Reference = string.IsNullOrEmpty(arcancil[2]) ? "" : arcancil[2];
                    arcancilOne.Produits = string.IsNullOrEmpty(arcancil[3]) ? "" : arcancil[3];
                    newArcancil.Add(arcancilOne);
                }
                var result = arcancailDal.Insert(newArcancil);

                if (result != arcancils.Count)
                {
                    return false;
                }
            }

            return true;
        }


        public bool ImportCatalogueFromExcel(string filePath)
        {
            if (!File.Exists(filePath) && !ExcelHelper.IsExcel(filePath))
            {
                return false;
            }

            var excelHelper = new ExcelHelper(filePath);
            var catalogues = excelHelper.GetDataBySheetName("Products Catalogue ");
            
            if (catalogues != null && catalogues.Count > 0)
            {
                //first we need truncate cities table delete the old data
                var catalogueDal = Factory.Instance().GetService<ICatalogueDal>();
                catalogueDal.TruncateTable<CatalogueEntity>();
                //then add the new city data
                var newCatalogue = new List<CatalogueEntity>();
                catalogues.RemoveRange(0,7);
                foreach (var catalogue in catalogues)
                {
                    catalogue.RemoveAt(0);
                    var catalogueOne = new CatalogueEntity();
                    catalogueOne.FCompany = string.IsNullOrEmpty(catalogue[0]) ? "" : catalogue[0];
                    catalogueOne.EBrand = string.IsNullOrEmpty(catalogue[1]) ? "" : catalogue[1];
                    catalogueOne.CBrand = string.IsNullOrEmpty(catalogue[2]) ? "" : catalogue[2];
                    catalogueOne.SubCategory = string.IsNullOrEmpty(catalogue[3]) ? "" : catalogue[3];
                    catalogueOne.SecondCategory = string.IsNullOrEmpty(catalogue[4]) ? "" : catalogue[4];
                    catalogueOne.TertiaryCategory = string.IsNullOrEmpty(catalogue[5]) ? "" : catalogue[5];
                    catalogueOne.TmallFees = string.IsNullOrEmpty(catalogue[6]) ? 0 : decimal.Parse(catalogue[6]);
                    catalogueOne.MainNum = string.IsNullOrEmpty(catalogue[7]) ? 0 : decimal.Parse(catalogue[7]);
                    catalogueOne.SubNum = string.IsNullOrEmpty(catalogue[8]) ? 0 : decimal.Parse(catalogue[8]);
                    catalogueOne.EFullProductName = string.IsNullOrEmpty(catalogue[9]) ? "" : catalogue[9];
                    catalogueOne.CFullProductName = string.IsNullOrEmpty(catalogue[10]) ? "" : catalogue[10];
                    catalogueOne.EColor = string.IsNullOrEmpty(catalogue[11]) ? "" : catalogue[11];
                    catalogueOne.CColor = string.IsNullOrEmpty(catalogue[12]) ? "" : catalogue[12];
                    catalogueOne.BarEnCode = string.IsNullOrEmpty(catalogue[13]) ? "" : catalogue[13];
                    catalogueOne.ProductRef = string.IsNullOrEmpty(catalogue[14]) ? "" : catalogue[14];
                    catalogueOne.CustomsCodification = string.IsNullOrEmpty(catalogue[15]) ? "" : catalogue[15];
                    catalogueOne.SLength = string.IsNullOrEmpty(catalogue[16]) ? 0 : decimal.Parse(catalogue[16]);
                    catalogueOne.SWidth = string.IsNullOrEmpty(catalogue[17]) ? 0 : decimal.Parse(catalogue[17]);
                    catalogueOne.SHauteur = string.IsNullOrEmpty(catalogue[18]) ? 0 : decimal.Parse(catalogue[18]);
                    catalogueOne.WeightGr = string.IsNullOrEmpty(catalogue[19]) ? 0 : decimal.Parse(catalogue[19]);
                    catalogueOne.WeightKg = string.IsNullOrEmpty(catalogue[20]) ? 0 : decimal.Parse(catalogue[20]);
                    catalogueOne.EuMiniSalePrice = string.IsNullOrEmpty(catalogue[21]) ? 0 : decimal.Parse(catalogue[21]);
                    catalogueOne.RmbMiniSalePrice = string.IsNullOrEmpty(catalogue[22]) ? 0 : decimal.Parse(catalogue[22]);
                    catalogueOne.EuMarkupSalePrice = string.IsNullOrEmpty(catalogue[23]) ? 0 : decimal.Parse(catalogue[23]);
                    catalogueOne.RmbMarkupSalePrice = string.IsNullOrEmpty(catalogue[24]) ? 0 : decimal.Parse(catalogue[24]);
                    catalogueOne.EuShippingCost = string.IsNullOrEmpty(catalogue[25]) ? 0 : decimal.Parse(catalogue[25]);
                    catalogueOne.RmbShippingCost = string.IsNullOrEmpty(catalogue[26]) ? 0 : decimal.Parse(catalogue[26]);
                    catalogueOne.EuSalePrice = string.IsNullOrEmpty(catalogue[27]) ? 0 : decimal.Parse(catalogue[27]);
                    catalogueOne.RmbSalePrice = string.IsNullOrEmpty(catalogue[28]) ? 0 : decimal.Parse(catalogue[28]);
                    catalogueOne.Stocks = string.IsNullOrEmpty(catalogue[29]) ? "" : catalogue[29];
                    newCatalogue.Add(catalogueOne);
                }
                var result = catalogueDal.Insert(newCatalogue);

                if (result != catalogues.Count)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
