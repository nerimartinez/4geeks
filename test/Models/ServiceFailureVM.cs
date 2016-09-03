using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class ServiceFailureVM
    {
        public bool Success { get { return false; } }
        public int ErrorCode { get; set; }
        public string Error_Message { get; set; }
    }
}