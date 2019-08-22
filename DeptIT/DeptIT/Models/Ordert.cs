using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeptIT.Models
{

    public class Ordert
    {
        public int OrdertId { get; set; }
        public string Client { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        //public DateTime OrderDate { get; set; }
    }
}