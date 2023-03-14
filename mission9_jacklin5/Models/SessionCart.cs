using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission9_jacklin5.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {                                                                                                       //? means it is nullable
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();       //Checks if SessionCart already exists otherwise we create a new one. new means making new instance of a class

            return cart;
        }


        [JsonIgnore]        //Prevents from being serialized or deserialized
        public ISession Session { get; set; }

        public override void AddItem(Book book, int qty)        //Overides AddItem method in Cart.cs
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);      //this means this specific instance of JSON
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();   
            Session.Remove("Cart");           //Clears basket for us once the user is done
        }

    }
}
