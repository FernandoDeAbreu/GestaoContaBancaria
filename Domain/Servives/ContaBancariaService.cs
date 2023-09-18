using Domain.Interfaces.IContaBancaria;
using Domain.Interfaces.Services;
using Entities.Entities;

namespace Domain.Servives
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IContaBancaria _contaBancaria;

        public ContaBancariaService(IContaBancaria contaBancaria)
        {
            _contaBancaria = contaBancaria;
        }

        public async Task Depositar(ContaBancaria contaBancaria)
        {
            if (contaBancaria.EnumsTipoLancamento != Entities.Enums.EnumsTipoLancamento.Transferencia)
                contaBancaria.EnumsTipoLancamento = Entities.Enums.EnumsTipoLancamento.Deposito;

            var saldoAtual = await _contaBancaria.ObterSaldoConta(contaBancaria.Id);

            if (saldoAtual != null)
                contaBancaria.Saldo = saldoAtual.Saldo + contaBancaria.Valor;

            await _contaBancaria.Add(contaBancaria);
        }

        public async Task Sacar(ContaBancaria contaBancaria)
        {
            if (contaBancaria.EnumsTipoLancamento != Entities.Enums.EnumsTipoLancamento.Transferencia)
                contaBancaria.EnumsTipoLancamento = Entities.Enums.EnumsTipoLancamento.Saque;

            contaBancaria.Valor = contaBancaria.Valor * (-1);

            var saldoAtual = await _contaBancaria.ObterSaldoConta(contaBancaria.Id);

            if (saldoAtual != null)
                contaBancaria.Saldo = saldoAtual.Saldo + contaBancaria.Valor;
            
            await _contaBancaria.Add(contaBancaria);
        }

        public async Task Transferir(ContaBancaria contaBancaria)
        {
            contaBancaria.EnumsTipoLancamento = Entities.Enums.EnumsTipoLancamento.Transferencia;
            contaBancaria.Valor = contaBancaria.Valor * (-1);

            var saldoAtual = await _contaBancaria.ObterSaldoConta(contaBancaria.Id);

            if (saldoAtual != null)
                contaBancaria.Saldo = saldoAtual.Saldo + contaBancaria.Valor;

            await _contaBancaria.Add(contaBancaria);
        }

        public async Task<IList<ContaBancaria>> ObterExtratoConta(int Id)
        {
            return await _contaBancaria.ObterExtratoConta(Id);
        }

        public async Task<ContaBancaria> ObterSaldoConta(int id)
        {
            return await _contaBancaria.ObterSaldoConta(id);
        }
    }
}