using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// Gets all the articles
        /// </summary>
        /// <returns></returns>
        List<Article> GetAll();

        /// <summary>
        /// Gets an article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Article GetById(int id);

        /// <summary>
        /// Adds an article
        /// </summary>
        /// <param name="article"></param>
        void Add(Article article);

        /// <summary>
        /// Edits an article
        /// </summary>
        /// <param name="article"></param>
        void Edit(Article article);

        /// <summary>
        /// Deletes an article
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Gets all the articles by store id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Article> GetByStoreId(int id);
    }
}
