using Microsoft.AspNetCore.Mvc;
using NewSportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private INewStoreRepository repository;
        public NavigationMenuViewComponent(INewStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}