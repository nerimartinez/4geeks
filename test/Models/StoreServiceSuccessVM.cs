using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class StoreServiceSuccessVM : BaseServiceSuccessVM
    {        
        public List<Store> Stores { get; set; }        
    }
}