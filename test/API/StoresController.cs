using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.Auth;
using test.Helpers;
using test.Models;
using test.Models.Enums;

namespace test.API
{
    public class StoresController : ApiController
    {
        readonly IStoreService _storeService;

        public StoresController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [ValidationActionFilter]
        [Route("services/stores")]
        public object Get()
        {
            if (BasicHttpAuth.IsAuthorized())
            {
                try
                {
                    var stores = new StoreService().GetAll();
                    return new StoreServiceSuccessVM() { Stores = stores, Total_elements = stores.Count };
                }
                catch
                {
                    throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.ServerError, HttpStatusCode.InternalServerError));                    
                }
            }
            else
            {
                throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.NotAuthorized, HttpStatusCode.Unauthorized));                
            }
            }        
    }
}
