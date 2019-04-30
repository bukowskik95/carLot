using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarLot.Models;
using CarLot.Pages.Models;

namespace CarLot.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarLot.Models.CarLotContext _context;

        public IndexModel(CarLot.Models.CarLotContext context)
        {
            _context = context;
        }

        public IList<car> car { get;set; }

        public async Task OnGetAsync(string searchString)
        {

            var cars = from c in _context.car
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Type.Contains(searchString));
            }


            car = await _context.car.ToListAsync();
        }
    }
}
