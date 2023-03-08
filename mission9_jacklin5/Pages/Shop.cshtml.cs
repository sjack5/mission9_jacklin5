using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mission9_jacklin5.Models;

namespace mission9_jacklin5.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository repo {get; set;}

        public ShopModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public Cart cart { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int bookID)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookID);

            cart = new Cart();

            cart.AddItem(b, 1);

            return RedirectToPage();
        }
    }
}
