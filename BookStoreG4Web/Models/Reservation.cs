using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreG4Web.Models
{
    public class Reservation
    {
        //Telling Id is primary Key, and auto incremented by databse
        [Key]
        public int Reserve_Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] //Id is required cause it is primary key
        

        public string Book_Id { get; set; }
        
        public string Cus_Id { get; set; }

        public DateTime ReservedTime { get; set; } = DateTime.Now;

        //check if reservation is returned
        public bool IsReturn { get; set; } = false;
        public DateTime ReturnedTime { get; set; } 


    }
}