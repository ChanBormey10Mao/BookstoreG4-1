using System;
using BookStoreG4Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreG4Web.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		//Create a Table name Books with the attr as the Models.Book (id, title, isReserved)
		public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}

