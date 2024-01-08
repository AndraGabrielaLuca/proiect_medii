using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Companii
{
    public class IndexModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public IndexModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        public IList<Companie> Companie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Companie != null)
            {
                Companie = await _context.Companie.ToListAsync();
            }
        }
    }
}
