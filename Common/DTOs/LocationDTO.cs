using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs
{
    public class LocationDTO
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string ZIP { get; set; }

        public int Frequency { get; set; }


    }
}
