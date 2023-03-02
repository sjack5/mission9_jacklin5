using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }         //Allows us to use IQueryable Element in repository method
    }
}
