using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the Room:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Number of Bedrooms:")]
        public int Layout { get; set; }

        public int amenitiesCount { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRoom { get; set; }

        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {

        Studio = 0,
        [Display(Name="One Bedroom")]
        OneBedroom = 1,
        [Display(Name = "Two Bedroom")]
        TwoBedroom = 2
    }
}
