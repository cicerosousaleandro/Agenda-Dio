using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AgendaDio.Areas.Contatos.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32.SafeHandles;

namespace AgendaDio.Pages
{
    public class Index1Model : PageModel
    {
        private readonly IWebHostEnvironment env;
        private IWebHostEnvironment _env;
        private SafeFileHandle strFilePath;

        [BindProperty]
        public Contato Contato { get; set; }
        public Index1Model(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            //Salvar imagem
            Contato.Id = Guid.NewGuid();
            Contato.FotoUrl = Path.Combine("Images", "Contatos", $"{Contato.Id}-{Contato.Foto.FileName}");
            var fulPath = Path.Combine(_env.WebRootPath, Contato.FotoUrl);
            using(var fileStream = new FileStream(strFilePath, (FileAccess)FileMode.Create))
            {
                await Contato.Foto.CopyToAsync(fileStream, cancellationToken);
            }
            
            //todo: persistir os dados
            return RedirectToPage("Index");
        }
    }
}
