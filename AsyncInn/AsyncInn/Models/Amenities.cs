using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Amenities
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name of the Amenity:")]
        public string Name { get; set; }

        //Navigation Properties

        public ICollection<RoomAmenities> RoomAmenities { get; set; }


    }
}
