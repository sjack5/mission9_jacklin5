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
        public PaymentController()      //Constructor
        {

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Payment());
        }

        [HttpPost]
        public IActionResult Checkout(Payment payment)
        {

        }
    }
}
