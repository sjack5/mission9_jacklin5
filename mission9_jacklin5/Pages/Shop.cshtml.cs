using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission9_jacklin5.Infrastructure;
using mission9_jacklin5.Models;

namespace mission9_jacklin5.Pages
{
    public class ShopModel : PageModel                  //Model for our cart page
    {
        private IBookstoreRepository repo {get; set;}

        public ShopModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }           //So we can direct users back to where they were browsing
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();         //Keeps session alive as we move back to browsing or it creates a cart object if we haven't made one yet
        }

        public IActionResult OnPost(int bookID, string returnUrl)       //When we want to access the cart page we need to know what book we want to purchase and where to go back to
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookID);        //Check if book is in our database

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            cart.AddItem(b, 1);     //Calls the addItem function

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });   //Saves information for later use
        }
    }
}
