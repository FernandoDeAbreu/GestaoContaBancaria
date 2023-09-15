using Domain.Interfaces.IContaBancaria;
using Entities.Entities;
using Infra.DBContext;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ContaBancariaRepository : GenericRepository<ContaBancaria>, IContaBancaria
    {
        private readonly DbContextOptions<AppDBContext> _OptionsBuilder;

        public ContaBancariaRepository()
        {
            _OptionsBuilder = new DbContextOptions<AppDBContext>();
        }

        public async Task<IList<ContaBancaria>> ObterExtratoConta(int Id)
        {
            using (var saldo = new AppDBContext(_OptionsBuilder))
            {
                return await
                    saldo.ContaBancaria
                    .Where(s => s.UsuarioId == Id).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<ContaBancaria> ObterSaldoConta(int id)
        {
            using (var saldo = new AppDBContext(_OptionsBuilder))
            {
                return await saldo.ContaBancaria
                    .AsNoTracking()
                    .Where(x => x.UsuarioId.Equals(id))
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();
            }
        }
    }
}