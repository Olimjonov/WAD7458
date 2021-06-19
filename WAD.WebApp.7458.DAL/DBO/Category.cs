using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WAD.WebApp._7458.DAL.DBO
{
    public class Category
    {
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
