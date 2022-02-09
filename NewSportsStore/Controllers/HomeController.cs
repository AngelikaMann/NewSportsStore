using Microsoft.AspNetCore.Mvc;
using NewSportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewSportsStore.Models.ViewModels;

namespace NewSportsStore.Controllers
{
    public class HomeController : Controller
    {
        private INewStoreRepository repository;
        public HomeController(INewStoreRepository repo)
        {
            repository = repo;
        }        
        public int PageSize = 2;
        public ViewResult Index(string category,int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductID)
                        .Skip((productPage - 1) * PageSize)
                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?repository.Products.Count() : repository.Products
                    .Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });        
    }
}
