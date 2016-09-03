using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models.Enums
{
    public enum StatusErrorCodes
    {
        [StringValue("SSO")]
        BadRequest = 400,
        [StringValue("SSO")]
        NotAuthorized = 401,
        [StringValue("SSO")]
        RecordNotFound = 404,
        [StringValue("SSO")]
        ServerError = 500
    }
}