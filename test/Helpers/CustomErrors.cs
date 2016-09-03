using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using test.Models;
using test.Models.Enums;

namespace test.Helpers
{
    public static class CustomErrors
    {
        public static HttpResponseMessage CreateErrorMessage(StatusErrorCodes errorCode, HttpStatusCode status)
        {
            var error = new JavaScriptSerializer().Serialize(
                        new ServiceFailureVM()
                        {
                            ErrorCode = (int)errorCode,
                            Error_Message = errorCode.ToString()
                        });

            var resp = new HttpResponseMessage(status)
            {
                Content = new StringContent(error)
            };
            return resp;
        }
    }
}