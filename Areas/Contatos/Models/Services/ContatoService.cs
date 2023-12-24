using AgendaDio.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaDio.Areas.Contatos.Models.Services
{
    public class ContatoService : IContaoService
    {
        private readonly IGenericRepository<Contato> _contatoRepository;

        public ContatoService(IGenericRepository<Contato> contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task<bool> Adicionar(Contato contato, CancellationToken cancellationToken)
        {
            await _contatoRepository.AddAsync(contato, cancellationToken).ConfigureAwait(false);
            var result = await _contatoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
