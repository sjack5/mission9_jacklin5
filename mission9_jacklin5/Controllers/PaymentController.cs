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
        private IPaymentRepository repo { get; set; }
        private Cart cart { get; set; }

        public PaymentController(IPaymentRepository temp, Cart c)      //Constructor
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Payment());     //Creates new payment object for me
        }

        [HttpPost]
        public IActionResult Checkout(Payment payment)      //Checks if our payment is valid or not
        {
            if(cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if(ModelState.IsValid)          //This means payment is real, it has a real PaymentID
            {
                payment.cartItems = cart.Items.ToArray();
                repo.SavePayment(payment);
                cart.ClearCart();
                return View();
            }
            else
            {
                return View();          //If paymentid is not real, then it just takes us back
            }
        }
    }
}
