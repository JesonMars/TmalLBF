using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    /// <summary>
    /// arcancil entity
    /// </summary>
    public class ArcancilEntity:BaseEntity
    {
        /// <summary>
        /// the id of the products
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// the products name
        /// </summary>
        public string Products { get; set; }
    }
}
