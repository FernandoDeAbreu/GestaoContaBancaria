using Domain.Interfaces.Generic;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IContaBancaria
{
    public interface IContaBancaria : IGeneric<ContaBancaria>
    {
        Task<IList<ContaBancaria>> ObterExtratoConta(int Id);
        Task<ContaBancaria> ObterSaldoConta(int id);

    }
}
