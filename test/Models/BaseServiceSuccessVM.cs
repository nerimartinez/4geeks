using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class BaseServiceSuccessVM
    {
        public bool Success { get { return true; } }
        public int Total_elements { get; set; }
    }
}