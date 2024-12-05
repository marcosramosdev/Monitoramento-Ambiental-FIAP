using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Services;
using MonitoramentoAmbiental.ViewModel;

namespace MonitoramentoAmbiental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoIrrigacaoController : ControllerBase
    {
        private readonly HistoricoIrrigacaoService _historicoService;

        public HistoricoIrrigacaoController(HistoricoIrrigacaoService historicoService)
        {
            _historicoService = historicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historicos = await _historicoService.GetAllAsync();
            var viewModels = historicos.Select(h => new HistoricoIrrigacaoViewModel
            {
                Id = h.Id,
                DataInicio = h.DataHora, 
                DataFim = null, 
                Status = "Desconhecido" 
            });
            return Ok(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistoricoIrrigacaoViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var historico = new HistoricoIrrigacao
            {
                // Removido ConfiguracaoIrrigacaoId pois não existe na classe HistoricoIrrigacao
                DataHora = viewModel.DataInicio, // Supondo que DataInicio é DataHora
                VolumeIrrigado = 0, // Supondo que VolumeIrrigado não existe em HistoricoIrrigacaoViewModel
                ParqueId = 0, // Supondo que ParqueId não existe em HistoricoIrrigacaoViewModel
                Parque = new Parque() // Supondo que Parque não existe em HistoricoIrrigacaoViewModel
            };

            var created = await _historicoService.CreateAsync(historico);

            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, new HistoricoIrrigacaoViewModel
            {
                Id = created.Id,
                // Removido ConfiguracaoIrrigacaoId pois não existe na classe HistoricoIrrigacao
                DataInicio = created.DataHora, // Supondo que DataInicio é DataHora
                DataFim = null, // Supondo que DataFim não existe em HistoricoIrrigacao
                Status = "Desconhecido" // Supondo que Status não existe em HistoricoIrrigacao
            });
        }
    }
}
