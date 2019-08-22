using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeptIT.Models
{
    public class Order
    {
        public int Id;
        public string Client;
        public int ProductId;
        public int Count;
        public DateTime OrderDate;
    }
}