using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quilicura.Models
{
    public class OrderTBK
    {
        [Key]
        public int OrderId { get; set; }        
        public string AccountingDate { get; set; }
        public string SessionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public string VCI { get; set; }
        public string CommerceCode { get; set; }
        [ScaffoldColumn(false)]
        public string PaymentTypeCode { get; set; }
        public string AuthorizationCode { get; set; }
        public int ResponseCode { get; set; }
        [ScaffoldColumn(false)]
        public double Total { get; set; }
        public List<OrderDetailTBK> OrderDetails { get; set; }
    }
}