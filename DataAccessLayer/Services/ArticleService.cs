using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ArticleService : IArticleService
    {
        public List<Article> GetAll()
        {
            List<Article> result;
            using (var db = new SuperShoesContext())
            {
                result = db.Articles.Include("Store").ToList();
            }
            return result;
        }

        public Article GetById(int id)
        {
            Article result;
            using (var db = new SuperShoesContext())
            {
                result = db.Articles.Include("Store").SingleOrDefault(x=>x.ID == id);
            }
            return result;
        }

        public List<Article> GetByStoreId(int id)
        {
            List<Article> result;
            using (var db = new SuperShoesContext())
            {
                if (db.Stores.SingleOrDefault(x=>x.ID == id) != null)
                    result = db.Articles.Include("Store").Where(x => x.Store.ID == id).ToList();
                else
                    result = null;
            }
            return result;
        }

        public void Add(Article article)
        {
            using (var db = new SuperShoesContext())
            {
                article.Store = db.Stores.Single(x => x.ID == article.Store.ID);
                db.Articles.Add(article);
                db.SaveChanges();
            }
        }

        public void Edit(Article article)
        {
            using (var db = new SuperShoesContext())
            {
                var item = db.Articles.SingleOrDefault(x => x.ID == article.ID);
                if (item != null)
                {
                    item.Description = article.Description;
                    item.Name = article.Name;
                    item.Price = article.Price;
                    item.Store = db.Stores.Single(x => x.ID == article.Store.ID);
                    item.Total_in_shelf = article.Total_in_shelf;
                    item.Total_in_vault = article.Total_in_vault;                    
                }
                db.SaveChanges();
            }            
        }

        public void Delete(int id)
        {
            using (var db = new SuperShoesContext())
            {
                var item = db.Articles.SingleOrDefault(x => x.ID == id);
                if (item != null)
                {
                    db.Articles.Remove(item);
                    db.SaveChanges();
                }
            }
        }
    }
}
