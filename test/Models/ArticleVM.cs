using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class ArticleVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Total in Shelf")]
        public int Total_in_shelf { get; set; }
        [DisplayName("Total in Vault")]
        public int Total_in_vault { get; set; }
        [DisplayName("Store Name")]
        public string Store_Name { get; set; }
    }
}