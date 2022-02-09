using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSportsStore.Models
{
    public class EFNewStoreRepository:INewStoreRepository
    {
        private NewStoreDbContext context;
        public EFNewStoreRepository(NewStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;

        public void CreateProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
        }
        public void DeleteProduct(Product p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
        public void SaveProduct(Product p)
        {
            context.SaveChanges();
        }
    }
}
