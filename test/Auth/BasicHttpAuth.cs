using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace test.Auth
{
    public static  class BasicHttpAuth 
    {
        public static bool IsAuthorized()
        {
            //if (Thread.CurrentPrincipal.Identity.Name.Length == 0)
            {
                // Get the header value                
                var credentials =HttpContext.Current.Request.Headers["Authorization"];
                
                // ensure its schema is correct
                if (credentials != null)
                {
                    // get the credientials                    
                    int separatorIndex = credentials.IndexOf(':');
                    if (separatorIndex >= 0)
                    {
                        // get user and password
                        string passedUserName = credentials.Substring(0, separatorIndex);
                        string passedPassword = credentials.Substring(separatorIndex + 1);

                        // validate
                        var username = ConfigurationManager.AppSettings["username"];
                        var password = ConfigurationManager.AppSettings["password"];
                        if (passedUserName == username && passedPassword == password)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}