using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class CitiesEntity:BaseEntity
    {
        /// <summary>
        /// provice of chinese
        /// </summary>
        public string Pc { get; set; }
        /// <summary>
        /// province of english
        /// </summary>
        public string Pe { get; set; }
        /// <summary>
        /// city of chinese
        /// </summary>
        public string Cityc { get; set; }
        /// <summary>
        /// city of english
        /// </summary>
        public string Citye { get; set; }

    }
}
