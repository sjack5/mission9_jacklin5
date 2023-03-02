using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public class EFBookStoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        public EFBookStoreRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;         //IQueryable element allows us to query information from the database
    }
}
