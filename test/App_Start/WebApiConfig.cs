using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using System.Web.Script.Serialization;
using test.App_Start;
using test.DI;
using test.Models;
using test.Models.Enums;

namespace test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
   
            var container = new UnityContainer();
            container.RegisterType<IArticleService, ArticleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStoreService, StoreService>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);
        }
    }
    
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            var error= new JavaScriptSerializer().Serialize(new ServiceFailureVM() { ErrorCode = (int)StatusErrorCodes.BadRequest, Error_Message = StatusErrorCodes.BadRequest.ToString() });
            if (!modelState.IsValid)
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, error);
        }
    }
}
