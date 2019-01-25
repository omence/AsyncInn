using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        //Navigation Properties

        public ICollection<HotelRoom> HotelRoom { get; set; }


    }
}
