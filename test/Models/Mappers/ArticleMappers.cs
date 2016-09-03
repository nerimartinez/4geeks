using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models.Mappers
{
    public static class ArticleMappers
    {
        public static Article MapToArticle(AddEditArticleVM vm)
        {
            return new Article()
            {
                ID = vm.ID,
                Description = vm.Description,
                Name = vm.Name,
                Price = vm.Price,
                Store = new Store() { ID = vm.StoreId },
                Total_in_shelf = vm.Total_in_shelf,
                Total_in_vault = vm.Total_in_vault
            };
        }

       public static AddEditArticleVM MapToAddEditVM(Article article)
        {
            var vm = new AddEditArticleVM();
            vm.Description = article.Description;
            vm.ID = article.ID;
            vm.Name = article.Name;
            vm.Price = article.Price;
            vm.StoreId = article.Store.ID;
            vm.Total_in_shelf = article.Total_in_shelf;
            vm.Total_in_vault = article.Total_in_vault;
            return vm;
        }

        public static ArticleVM MapToVM(Article article)
        {
            var vm = new ArticleVM();
            vm.Description = article.Description;
            vm.ID = article.ID;
            vm.Name = article.Name;
            vm.Price = article.Price;
            vm.Store_Name = article.Store.Name;
            vm.Total_in_shelf = article.Total_in_shelf;
            vm.Total_in_vault = article.Total_in_vault;
            return vm;
        }
    }
}