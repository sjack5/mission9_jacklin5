using Microsoft.AspNetCore.Mvc;
using mission9_jacklin5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Components
{
    public class CartSummaryViewComponent: ViewComponent        //Use this to create a cart image on our index page
    {
            private Cart cart;
            public CartSummaryViewComponent(Cart cartService)
            {
                cart = cartService;
            }
            public IViewComponentResult Invoke()
            {
                return View(cart);
            }
    }
}
