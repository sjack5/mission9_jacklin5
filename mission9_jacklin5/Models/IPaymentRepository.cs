using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public interface IPaymentRepository
    {
        IQueryable<Payment> Payments { get; }

        void SavePayment(Payment payment);
    }
}
