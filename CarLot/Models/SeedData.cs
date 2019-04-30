using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarLot.Pages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarLot.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarLotContext(
                serviceProvider.GetRequiredService<DbContextOptions<CarLotContext>>()))
            {
                // Look for any movies.
                if (context.car.Any())
                {
                    return;   // DB has been seeded
                }


                context.car.AddRange(
                    new car
                    {
                        Name = "Ford Mustang",
                        Type = "Muscle",
                        ReleaseDate = DateTime.Parse("1968-1-1"),
                        Engine = 4.7,
                        Doors = 2,
                        Fuel = "Petrol",
                        Gearbox = "Automatic",
                        ImageUrl = "https://www.erclassics.com/media/wysiwyg/history/68_Mustang.jpg",
                    },

                    new car
                    {
                        Name = "Jaguar F-Type",
                        Type = "Luxury",
                        ReleaseDate = DateTime.Parse("2018-1-1"),
                        Engine = 3,
                        Doors = 2,
                        Fuel = "Petrol",
                        Gearbox = "Automatic",
                        ImageUrl = "https://m.atcdn.co.uk/a/media/w1024/10f5e2f5c599479aa9dbbccdb0cd949e.jpg",
                    },

                    new car
                    {
                        Name = "Porsche Cayman Coupe",
                        Type = "Sports",
                        ReleaseDate = DateTime.Parse("2013-1-1"),
                        Engine = 2.7,
                        Doors = 2,
                        Fuel = "Petrol",
                        Gearbox = "Automatic",
                        ImageUrl = "https://img.vcars.co.uk/1/listers/bigimages/131667_1.jpg",
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}