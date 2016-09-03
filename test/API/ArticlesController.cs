using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using test.Auth;
using test.Helpers;
using test.Models;
using test.Models.Enums;
using test.Models.Mappers;

namespace test.API
{
    public class ArticlesController : ApiController
    {
        readonly IArticleService _articleService;

        public ArticlesController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [ValidationActionFilter]
        [Route("services/articles")]
        public object Get()
        {
            if (BasicHttpAuth.IsAuthorized())
            {
                try
                {
                    var articles = _articleService.GetAll();
                    return new ArticlesServiceSuccessVM() { Articles = articles.Select(x => ArticleMappers.MapToVM(x)).ToList(), Total_elements = articles.Count };
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

        [ValidationActionFilter]
        [Route("services/articles/stores/{id}")]
        public object GetByStoreId(int id)
        {
            if (BasicHttpAuth.IsAuthorized())
            {
                List<Article> articles;
                try
                {
                    articles = _articleService.GetByStoreId(id);
                }
                catch
                {
                    throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.ServerError, HttpStatusCode.InternalServerError));
                }
                if (articles == null)
                    {
                        throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.RecordNotFound, HttpStatusCode.NotFound));                        
                    }
                    return new ArticlesServiceSuccessVM() { Articles = articles.Select(x => ArticleMappers.MapToVM(x)).ToList(), Total_elements = articles.Count };
                
            }
            else
            {
                throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.NotAuthorized, HttpStatusCode.Unauthorized));                
            }
        }

        [ValidationActionFilter]
        [Route("services/articles/{id}")]
        public object GetById(int id)
        {
            if (BasicHttpAuth.IsAuthorized())
            {
                Article article;
                try
                {
                    article = _articleService.GetById(id);
                }
                catch
                {
                    throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.ServerError, HttpStatusCode.InternalServerError));
                }
                if (article == null)
                    {
                        throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.RecordNotFound, HttpStatusCode.NotFound));                        
                    }
                    return new ArticleServiceSuccessVM() { Article = ArticleMappers.MapToVM(article), Total_elements = 1 };                
            }
            else
            {                
                throw new HttpResponseException(CustomErrors.CreateErrorMessage(StatusErrorCodes.NotAuthorized, HttpStatusCode.Unauthorized));                
            }
        }
    }

    
}
