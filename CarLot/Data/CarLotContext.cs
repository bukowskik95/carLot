using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarLot.Pages.Models;

namespace CarLot.Models
{
    public class CarLotContext : DbContext
    {
        public CarLotContext (DbContextOptions<CarLotContext> options)
            : base(options)
        {
        }

        public DbSet<CarLot.Pages.Models.car> car { get; set; }
    }
}
