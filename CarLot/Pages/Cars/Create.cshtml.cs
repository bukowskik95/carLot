using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarLot.Models;
using CarLot.Pages.Models;

namespace CarLot.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarLot.Models.CarLotContext _context;

        public CreateModel(CarLot.Models.CarLotContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public car car { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.car.Add(car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}