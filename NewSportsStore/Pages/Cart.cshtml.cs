using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewSportsStore.Models;
using System.Linq;


namespace NewSportsStore.Pages
{
    public class CartModel : PageModel
    {
        private INewStoreRepository reposit;
        public CartModel(INewStoreRepository repo, Cart cartService)
      
        {
            reposit = repo;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = reposit.Products
            .FirstOrDefault(p => p.ProductID == productId);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Product.ProductID == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}