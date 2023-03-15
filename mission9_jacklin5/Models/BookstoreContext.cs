using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mission9_jacklin5.Models
{
    public partial class BookstoreContext : DbContext       //Context file is link from our code to our database
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }       //Creates Books variable that we will use a lot later
        public DbSet<Payment> Payments { get; set; }    //Allows us to make a table in the database called Payment and will allow us to store information found in our Payment model
    }
}
