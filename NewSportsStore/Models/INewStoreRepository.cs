using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSportsStore.Models
{
    public interface INewStoreRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
    }
}
