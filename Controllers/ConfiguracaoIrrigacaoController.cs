using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Services;
using MonitoramentoAmbiental.ViewModel;

namespace MonitoramentoAmbiental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracaoIrrigacaoController : ControllerBase
    {
        private readonly ConfiguracaoIrrigacaoService _configuracaoService;

        public ConfiguracaoIrrigacaoController(ConfiguracaoIrrigacaoService configuracaoService)
        {
            _configuracaoService = configuracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var configuracoes = await _configuracaoService.GetAllAsync();
            var viewModels = configuracoes.Select(c => new ConfiguracaoIrrigacaoViewModel
            {
                Id = c.Id,
                ParqueId = c.ParqueId,
                Nome = c.Nome,
                TemperaturaMinima = c.TemperaturaMinima,
                TemperaturaMaxima = c.TemperaturaMaxima,
                UmidadeMinima = c.UmidadeMinima,
                UmidadeMaxima = c.UmidadeMaxima,
                Ativo = true,
                Parque = c.Parque
            });
            return Ok(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConfiguracaoIrrigacaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var configuracao = new ConfiguracaoIrrigacao
            {
                ParqueId = viewModel.ParqueId,
                Nome = viewModel.Nome,
                TemperaturaMinima = viewModel.TemperaturaMinima,
                TemperaturaMaxima = viewModel.TemperaturaMaxima,
                UmidadeMinima = viewModel.UmidadeMinima,
                UmidadeMaxima = viewModel.UmidadeMaxima,
                Ativo = false,
                Parque = viewModel.Parque
            };

            var created = await _configuracaoService.CreateAsync(configuracao);

            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, new ConfiguracaoIrrigacaoViewModel
            {
                Id = created.Id,
                ParqueId = created.ParqueId,
                Nome = created.Nome,
                TemperaturaMinima = created.TemperaturaMinima,
                TemperaturaMaxima = created.TemperaturaMaxima,
                UmidadeMinima = created.UmidadeMinima,
                UmidadeMaxima = created.UmidadeMaxima,
                Ativo = created.Ativo,
                Parque = created.Parque
            });
        }
    }
}
