using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class StoreService : IStoreService
    {
        public List<Store> GetAll()
        {
            List<Store> result;
            using (var db = new SuperShoesContext())
            {
                result = db.Stores.ToList();
            }
            return result;
        }

        public Store GetById(int id)
        {
            Store result;
            using (var db = new SuperShoesContext())
            {
                result = db.Stores.SingleOrDefault(x => x.ID == id);
            }
            return result;
        }

        public void Add(Store store)
        {
            using (var db = new SuperShoesContext())
            {
                db.Stores.Add(store);
                db.SaveChanges();
            }
        }

        public void Edit(Store store)
        {
            using (var db = new SuperShoesContext())
            {
                var item = db.Stores.SingleOrDefault(x => x.ID == store.ID);
                if (item != null)
                {
                    item.Address = store.Address;
                    item.Name = store.Name;
                }
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new SuperShoesContext())
            {
                var item = db.Stores.SingleOrDefault(x => x.ID == id);
                if (item != null)
                {
                    var articles = db.Articles.Where(x => x.Store.ID == id);
                    foreach (var art in articles)
                    {
                        db.Articles.Remove(art);
                    }
                    db.Stores.Remove(item);
                    db.SaveChanges();
                }
            }
        }
    }
}
