using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Models.Services
{
    public interface IContaoService
    {
        Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken);
    }
}
