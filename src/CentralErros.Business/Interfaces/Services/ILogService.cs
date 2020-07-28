using System;
using System.Threading.Tasks;
using CentralErros.Business.Models;

namespace CentralErros.Business.Interfaces.Services
{
    public interface ILogService : IDisposable
    {
        Task Adicionar(Log log);
        Task Atualizar(Log log);
        Task Remover(Guid id);
    }
}
