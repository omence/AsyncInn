using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Required]
        [Display(Name = "Name of the Hotel:")]
        public int HotelID { get; set; }

        [Required]
        [Display(Name = "Room Number:")]
        public int RoomNumber { get; set; }

        public decimal RoomID { get; set; }

        [Required]
        [Display(Name = "Price for Room:")]
        public decimal Rate { get; set; }

        
        [Display(Name = "Pet Friendly Room:")]
        public bool PetFriendly { get; set; }


        //Navigation Properties

        public Hotel Hotel { get; set; }

        public Room Room { get; set; }

    }
}
