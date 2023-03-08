using Microsoft.AspNetCore.Mvc;
using mission9_jacklin5.Models;
using mission9_jacklin5.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books      //Query to pass along the correct info from our model
                .Where(p => p.Category == bookCategory | bookCategory == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo     //Information needed to make our pages look right. Grab it from PageInfo ViewModels
                {
                    TotalNumBooks = (bookCategory == null ? repo.Books.Count() : repo.Books.Where(p=> p.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);     //Pass this to view for it to iterate through
        }
    }
}
