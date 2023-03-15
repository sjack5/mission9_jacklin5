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
        private Cart cart { get; set; }     //This brings in the session, this is why we added session material to the cart.cs file

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

            if(ModelState.IsValid)          //This means payment is not empty, it is zero
            {
                payment.cartItems = cart.Items.ToArray();       //Stores items for us
                repo.SavePayment(payment);      //Found in our EFPaymentRepository. If there is no PaymentId, it will add payment for us
                cart.ClearCart();
                return RedirectToPage("/PaymentConfirmation");
            }
            else
            {
                return View();          //If paymentid is not real, then it just takes us back
            }
        }
    }
}
