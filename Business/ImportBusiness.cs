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
                    arcancilOne.Reference = string.IsNullOrEmpty(arcancil[0]) ? "" : arcancil[0];
                    arcancilOne.Products = string.IsNullOrEmpty(arcancil[1]) ? "" : arcancil[1];
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
    }
}
