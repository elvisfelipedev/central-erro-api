using System;
using System.Threading.Tasks;
using CentralErros.Business.Interfaces;
using CentralErros.Business.Interfaces.Repositories;
using CentralErros.Business.Interfaces.Services;
using CentralErros.Business.Models;
using CentralErros.Business.Models.Validations;

namespace CentralErros.Business.Services
{
    public class LogService : BaseService, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository, INotificador notificador) : base(notificador)
        {
            _logRepository = logRepository;
        }

        public async Task Adicionar(Log log)
        {
            if (!ExecutarValidacao(new LogValidation(), log)) return;

            await _logRepository.Adicionar(log);
        }

        public async Task Atualizar(Log log)
        {
            if (!ExecutarValidacao(new LogValidation(), log)) return;

            await _logRepository.Atualizar(log);
        }

        public async Task Remover(Guid id)
        {
            await _logRepository.Remover(id);
        }

        public void Dispose()
        {
            _logRepository?.Dispose();
        }
    }
}
