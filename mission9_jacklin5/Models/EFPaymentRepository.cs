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

        public IQueryable<Payment> Payments => context.Payments.Include(x => x.Items);

        public void SaveDonation(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
