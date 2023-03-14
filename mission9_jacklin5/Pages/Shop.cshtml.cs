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

        public ShopModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }           //So we can direct users back to where they were browsing
        
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
        }

        public IActionResult OnPost(int bookID, string returnUrl)       //When we want to access the cart page we need to know what book we want to purchase and where to go back to
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookID);        //Check if book is in our database


            cart.AddItem(b, 1);     //Calls the addItem function

            return RedirectToPage(new { ReturnUrl = returnUrl });   //Takes us back to where we were
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)     //Method for our form we created on shop.cshtml page
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);   //Finds the book in our list of books and returns the instance of Book that it belongs to

            return RedirectToPage(new { ReturnUrl = returnUrl });   //Takes us back to where we were
        }
    }
}
