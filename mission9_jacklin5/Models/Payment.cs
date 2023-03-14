using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public class Payment
    {
        [Key]
        [BindNever] //Not information that can be passed through the url. Makes it more secure
        public int PaymentId { get; set; }

        [BindNever]
        public ICollection<CartItem> cartItems { get; set; } 
        
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the first address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage ="Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage ="Please enter a state")]
        public string State { get; set; }

        public string Zip { get; set; }

    }
}
