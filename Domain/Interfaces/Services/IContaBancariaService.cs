using Entities.Entities;

namespace Domain.Interfaces.Services
{
    public interface IContaBancariaService
    {
        Task Depositar(ContaBancaria contaBancaria);

        Task Sacar(ContaBancaria contaBancaria);

        Task Transferir(ContaBancaria contaBancaria);

        Task<ContaBancaria> ObterSaldoConta(int id);

        Task<IList<ContaBancaria>> ObterExtratoConta(int Id);
    }
}