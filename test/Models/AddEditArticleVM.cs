using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Models
{
    public class AddEditArticleVM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }        
        [Required]
        [DisplayName("Price $")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Total in shelf")]
        public int Total_in_shelf { get; set; }
        [Required]
        [DisplayName("Total in vault")]
        public int Total_in_vault { get; set; }
        [Required(ErrorMessage = "You must add a store before adding an article.")]
        [DisplayName("Store")]   
        public int StoreId { get; set; }        
    }
}