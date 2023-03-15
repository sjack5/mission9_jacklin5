using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public class EFPaymentRepository : IPaymentRepository
    {
        private BookstoreContext context;
        public EFPaymentRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Payment> Payments => context.Payments.Include(x => x.cartItems).ThenInclude(x=>x.Book);      //Want to get all the information that's found in our cartItems then all the information that is with that book

        public void SavePayment(Payment payment)
        {
            context.AttachRange(payment.cartItems.Select(x => x.Book));

            if (payment.PaymentId == 0)
            {
                context.Payments.Add(payment);
            }

            context.SaveChanges();          //Saves the changes to our database
        }
    }
}
