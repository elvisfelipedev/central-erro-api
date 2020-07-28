using CentralErros.Business.Interfaces.Repositories;
using CentralErros.Business.Models;
using CentralErros.Data.Context;

namespace CentralErros.Data.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(Contexto context) : base(context) { }
    }
}
