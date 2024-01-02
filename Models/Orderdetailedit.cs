using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jewelly.Models
{
    public class Orderdetailedit
    {
        public Orderdetail OrderDetail { get; set; }
        public SelectList Products { get; set; }

        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
            public int? ID { get; set; }

    }
}