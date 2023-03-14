using Microsoft.AspNetCore.Mvc;
using mission9_jacklin5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Payment());
        }
    }
}
