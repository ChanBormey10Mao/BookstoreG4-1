using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreG4Web.Models
{
    public class Reservation
    {
        //Telling Id is primary Key
        [Key]

        public string Reserve_Id { get; set; }
        [Required] //Id is required cause it is primary key

        public string Book_Id { get; set; }
        
        public string Cus_Id { get; set; }
        



        //set createDateTime to be the present time
        public DateTime ReserveTime { get; set; } = DateTime.Now;
        public DateTime ReturnTime { get; set; } = DateTime.Now + TimeSpan.FromDays(14);



    }
}