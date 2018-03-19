using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeptIT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Type { get; set; }
        //public DateTime CreateDate { get; set; }
    }
}