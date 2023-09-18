using Domain.Interfaces.Services;
using Entities.Entities;
using GestaoContaBancaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestaoContaBancaria.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaService _iContaBancariaService;
        private readonly UserManager<Usuario> _userManager;

        public ContaBancariaController(IContaBancariaService iContaBancariaService, UserManager<Usuario> userManager)
        {
            _iContaBancariaService = iContaBancariaService;
            _userManager = userManager;
        }

        [HttpPost("/api/Depositar")]
        [Produces("application/json")]
        public async Task<object> Depositar(ContaBancaria contaBancaria)
        {
            if (contaBancaria.Valor <= 0)
                return Ok("Informe um valor valido!");

            await _iContaBancariaService.Depositar(contaBancaria);

            return contaBancaria;
        }

        [HttpPost("/api/Sacar")]
        [Produces("application/json")]
        public async Task<object> Sacar(ContaBancaria contaBancaria)
        {
            if (contaBancaria.Valor <= 0)
                return Ok("Informe um valor valido!");

            await _iContaBancariaService.Sacar(contaBancaria);

            return contaBancaria;
        }

        [HttpPost("/api/Transferir")]
        [Produces("application/json")]
        public async Task<object> Transferir(Transferir transferir)
        {
            var destino = new ContaBancaria()
            {
                Descricao = transferir.Descricao,
                DataLancemanto = DateTime.Now,
                EnumsTipoLancamento = Entities.Enums.EnumsTipoLancamento.Transferencia,
                Valor = transferir.Valor,
                UsuarioId = transferir.UsuarioDestinoId
            };
            var origem = new ContaBancaria()
            {
                Descricao = transferir.Descricao,
                DataLancemanto = DateTime.Now,
                EnumsTipoLancamento = Entities.Enums.EnumsTipoLancamento.Transferencia,
                Valor = transferir.Valor,
                UsuarioId = transferir.UsuarioOrigemId
            };

            await _iContaBancariaService.Sacar(destino);
            await _iContaBancariaService.Depositar(origem);


            return Ok();
        }

        [HttpGet("/api/ObterSaldoConta")]
        [Produces("application/json")]
        public async Task<object> ObterSaldoConta(int id)
        {
            var saldo = await _iContaBancariaService.ObterSaldoConta(id);

            return saldo.Saldo;
        }

        [HttpGet("/api/ObterExtratoConta")]
        [Produces("application/json")]
        public async Task<object> ObterExtratoConta(int id)
        {
            return await _iContaBancariaService.ObterExtratoConta(id);
        }
    }
}