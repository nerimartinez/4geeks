using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models.Mappers
{
    public static class StoreMappers
    {
        public static StoreVM MapToVM(Store store)
        {
            return new StoreVM()
            {
                Address = store.Address,
                ID = store.ID,
                Name = store.Name
            };            
        }

        public static Store MapToModel(StoreVM storeVM)
        {
            return new Store()
            {
                Address = storeVM.Address,
                ID = storeVM.ID,
                Name = storeVM.Name
            };
        }
    }
}