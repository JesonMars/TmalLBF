using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessInterface
{
    public interface IImportBusiness:IBaseBusiness
    {
        bool ImportCitiesFromExcel(string filePath);
        bool ImportArcancilFromExcel(string filePath);
        bool ImportCatalogueFromExcel(string filePath);
    }



}
