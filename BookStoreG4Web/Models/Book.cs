using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreG4Web.Models
{
	public class Book
	{
		//Telling Id is primary Key
		[Key]

		public int Id { get; set; }
		[Required] //Id is required cause it is primary key

		public string Title { get; set; }

		//check for if the book is reserved
        public bool IsReserved { get; set; }

        //set createDateTime to be the present time
        //public DateTime CreateDateTime { get; set; } = DateTime.Now;



    }
}

