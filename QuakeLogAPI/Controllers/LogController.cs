using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuakeLogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogInterface _parser;

        public GameController(ILogInterface parser)
        {
            _parser = parser;
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport(string logPath)
        {

            try
            {
                logPath = logPath.Trim('"');

                if (!System.IO.File.Exists(logPath))
                {
                    return NotFound(new
                    {
                        status = 404,
                        message = "Arquivo não encontrado."
                    });
                }

                var resultado = await _parser.ProcessarLog(logPath);

                if (resultado == null || resultado.Games.Count == 0)
                {
                    return Ok(new { message = "Nenhum jogo encontrado no log." });
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = 500,
                    message = "Erro ao processar o log.",
                    details = ex.Message
                });
            }
        }
    }

}
