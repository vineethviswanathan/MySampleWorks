using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int ID { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string ZIP { get; set; }
    }
}
