﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_jacklin5.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();           //Creates cart that allows users to put multiple books in

        public void AddItem(Book book, int qty)
        {
            CartItem line = Items
                .Where(p => p.Book.BookId == book.BookId)       //Matches ids so we grab the right book
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartItem
                {
                    Book = book,            //Lists new books
                    Quantity = qty

                });
            }
            else
            {
                line.Quantity += qty;       //Adds book if more than one copy of a book is purchased
            }
        }

        public double CalculateTotal()          //Takes total for user to see how much they'd spend on books
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class CartItem           //All the items that make up an individual book that gets added to the cart
    {
        public int ItemId { get; set; }
        public Book Book { get; set; }      //Need this so we can get price
        public int Quantity { get; set; }
    }
}
