using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreG4Web.Models
{
    public class Customer
    {
        //Telling Id is primary Key
        [Key]
        public string Cus_Id { get; set; }
        [Required] //Id is required cause it is primary key

        public string Cus_Name { get; set; }
        public string Cus_Email { get; set; }
        public string Cus_Password { get; set; }



    }
}

