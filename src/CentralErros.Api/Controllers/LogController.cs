using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CentralErros.Api.ViewModels;
using CentralErros.Business.Interfaces;
using CentralErros.Business.Interfaces.Repositories;
using CentralErros.Business.Interfaces.Services;
using CentralErros.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralErros.Api.Controllers
{
    [Authorize]
    [Route("api/logs")]
    public class LogController : MainController
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;


        public LogController(ILogRepository logRepository, 
                             ILogService logService,
                             IMapper mapper,
                             INotificador notificador) : base(notificador)
        {
            _logRepository = logRepository;
            _logService = logService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LogViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<LogViewModel>>(await _logRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<LogViewModel> ObterLogPorId(Guid id)
        {
            return _mapper.Map<LogViewModel>(await _logRepository.ObterPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<LogViewModel>> Adicionar(LogViewModel logViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _logService.Adicionar(_mapper.Map<Log>(logViewModel));

            return CustomResponse(logViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LogViewModel>> Atualizar(Guid id, LogViewModel logViewModel)
        {
            if (id != logViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(logViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _logService.Atualizar(_mapper.Map<Log>(logViewModel));

            return CustomResponse(logViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<LogViewModel>> Excluir(Guid id)
        {
            var logViewModel = await ObterLogPorId(id);

            if (logViewModel == null) return NotFound();

            await _logService.Remover(id);

            return CustomResponse(logViewModel);
        }
    }
}
