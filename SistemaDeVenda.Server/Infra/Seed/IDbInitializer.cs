using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVenda.Server.Infra.Seed
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}
