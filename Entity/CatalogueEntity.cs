using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CatalogueEntity:BaseEntity
    {
        /// <summary>
        /// the french company name 
        /// </summary>
        public string FCompany { get; set; }
        /// <summary>
        /// the english brand name
        /// </summary>
        public string EBrand { get; set; }
        /// <summary>
        /// the chinese brand name
        /// </summary>
        public string CBrand { get; set; }
        /// <summary>
        /// TMALL  Sub Category of Product*
        /// </summary>
        public string SubCategory { get; set; }
        /// <summary>
        /// TMALL Secondary category of product 
        /// </summary>
        public string SecondCategory { get; set; }
        /// <summary>
        /// TMALL Tertiary category of product
        /// </summary>
        public string TertiaryCategory { get; set; }
        /// <summary>
        /// tamll fees
        /// </summary>
        public decimal TmallFees { get; set; }
        /// <summary>
        /// main number
        /// </summary>
        public decimal MainNum { get; set; }
        /// <summary>
        /// sub number
        /// </summary>
        public decimal SubNum { get; set; }
        /// <summary>
        /// english name of the product
        /// </summary>
        public string EFullProductName { get; set; }
        /// <summary>
        /// chinese name of the product
        /// </summary>
        public string CFullProductName { get; set; }
        /// <summary>
        /// color name of english
        /// </summary>
        public string EColor { get; set; }
        public string CColor { get; set; }
        public string BarEnCode { get; set; }
        public string ProductRef { get; set; }
        public string CustomsCodification { get; set; }
        public decimal SLength { get; set; }
        public decimal SWidth { get; set; }
        public decimal SHauteur { get; set; }
        public decimal WeightGr { get; set; }
        public decimal WeightKg { get; set; }
        public decimal EuMiniSalePrice { get; set; }
        public decimal RmbMiniSalePrice { get; set; }
        public decimal EuMarkupSalePrice { get; set; }
        public decimal RmbMarkupSalePrice { get; set; }
        public decimal EuShippingCost { get; set; }
        public decimal RmbShippingCost { get; set; }
        public decimal EuSalePrice { get; set; }
        public decimal RmbSalePrice { get; set; }
        public string Stocks { get; set; }

    }
}
