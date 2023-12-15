using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaDio.Areas.Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaDio.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public Contato Contato { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            //todo: persistir os dados
            return RedirectToPage("Index");
        }
    }
}
