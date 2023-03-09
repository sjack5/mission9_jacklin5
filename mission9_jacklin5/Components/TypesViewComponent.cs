using Microsoft.AspNetCore.Mvc;
using mission9_jacklin5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Components
{
    public class TypesViewComponent : ViewComponent             //Consolidates information for us to use later
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];       //Lists all the categories of books

            var types = repo.Books          //Uses Books to order the list of books that are found on the website
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return View(types);
        }
    }
}
