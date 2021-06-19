using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WAD.WebApp._7458.DAL.DBO
{
    public class Brand
    {
        public int BrandId { get; set; }

        [DisplayName("Category Name")]
        public string BrandName { get; set; }
    }
}
