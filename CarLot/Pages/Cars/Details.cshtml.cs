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
    public class DetailsModel : PageModel
    {
        private readonly CarLot.Models.CarLotContext _context;

        public DetailsModel(CarLot.Models.CarLotContext context)
        {
            _context = context;
        }

        public car car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            car = await _context.car.FirstOrDefaultAsync(m => m.ID == id);

            if (car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
