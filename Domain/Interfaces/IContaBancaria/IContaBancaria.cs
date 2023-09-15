using Domain.Interfaces.Generic;
using Entities.Entities;

namespace Domain.Interfaces.IContaBancaria
{
    public interface IContaBancaria : IGeneric<ContaBancaria>
    {
        Task<IList<ContaBancaria>> ObterExtratoConta(int Id);

        Task<ContaBancaria> ObterSaldoConta(int id);
    }
}