using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {

        public int ID { get; set; }

        
        [Display(Name = "Name of the Hotel:")]
        public string Name { get; set; }

        
        [Display(Name = "City Location:")]
        public string Address { get; set; }

        
        [Display(Name = "Hotel Phone Number:")]
        public string Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRoom { get; set; }


    }
}
