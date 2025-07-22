using Application.Interfaces;
using Domain.Entities;
using Domain.Interface;


namespace Application.Services
{
    public class LogServices : ILogInterface
    {
        private readonly ILogRepository _logRepository;
        public LogServices(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<ParseLogResult> ProcessarLog(string filePath)
        {
               var resultado = await _logRepository.ParseLog(filePath);
               return resultado;   
        }
    }
}
