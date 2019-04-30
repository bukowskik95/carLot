using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarLot.Models;
using CarLot.Pages.Models;

namespace CarLot.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarLot.Models.CarLotContext _context;

        public EditModel(CarLot.Models.CarLotContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!carExists(car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool carExists(int id)
        {
            return _context.car.Any(e => e.ID == id);
        }
    }
}
