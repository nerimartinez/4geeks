using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class ArticlesServiceSuccessVM : BaseServiceSuccessVM
    {        
        public List<ArticleVM> Articles { get; set; }        
    }
}