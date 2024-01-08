using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Zboruri
{
    public class IndexModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public IndexModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        public IList<Zbor> Zbor { get;set; } = default!;
        public ZborData ZborD { get; set; }
        public int ZborID { get; set; }
        public int TerminalID { get; set; }
        public async Task OnGetAsync(int? id, int? terminalID)
        {
            ZborD = new ZborData();

            ZborD.Zboruri = await _context.Zbor
            .Include(b => b.Companie)
            .Include(b => b.ZborTerminale)
            .ThenInclude(b => b.Terminal)
            .AsNoTracking()
            .OrderBy(b => b.Destinatie)
            .ToListAsync();
            if (id != null)
            {
                ZborID = id.Value;
                Zbor zbor = ZborD.Zboruri
                .Where(i => i.ID == id.Value).Single();
                ZborD.Terminale = zbor.ZborTerminale.Select(s => s.Terminal);
            }
        }
    }
}
