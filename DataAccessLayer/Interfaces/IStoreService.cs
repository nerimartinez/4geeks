using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStoreService
    {
        /// <summary>
        /// Gets all the stores
        /// </summary>
        /// <returns></returns>
        List<Store> GetAll();

        /// <summary>
        /// Gets a store by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Store GetById(int id);

        /// <summary>
        /// Adds a store
        /// </summary>
        /// <param name="store"></param>
        void Add(Store store);

        /// <summary>
        /// Edits a store
        /// </summary>
        /// <param name="store"></param>
        void Edit(Store store);

        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
