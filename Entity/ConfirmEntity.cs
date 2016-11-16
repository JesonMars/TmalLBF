using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class ConfirmEntity:BaseEntity
    {
        public int orderid { get;set; }
        public DateTime? createdate { get; set; }
        public DateTime? createtime { get; set; }
        public string opname { get; set; }
        public string bstatus { get;set; }
        public string tstatus { get; set; }
        public string tcreatedate { get; set; }
        public string tcreatetime { get; set; }
        public string fopstatus { get; set; }
        public string wastetime { get; set; }
        public int isused { get; set; }
    }
}
