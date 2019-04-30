using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarLot.Pages.Models
{
    public class car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public double Engine { get; set; }
        public int Doors { get; set; }
        public string Fuel { get; set; }
        public string Gearbox { get; set; }
        public string ImageUrl { get; set; }
    }
}
