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
    public class DeleteModel : PageModel
    {
        private readonly CarLot.Models.CarLotContext _context;

        public DeleteModel(CarLot.Models.CarLotContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            car = await _context.car.FindAsync(id);

            if (car != null)
            {
                _context.car.Remove(car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
