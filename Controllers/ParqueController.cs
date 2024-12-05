using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Services;
using MonitoramentoAmbiental.ViewModel;

namespace MonitoramentoAmbiental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueController : ControllerBase
    {
        private readonly ParqueService _parqueService;

        public ParqueController(ParqueService parqueService)
        {
            _parqueService = parqueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var parques = await _parqueService.GetAllAsync();
            var viewModels = parques.Select(p => new ParqueViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Localizacao = p.Localizacao,
                Area = p.Area,
                CondicoesClimaticas = p.CondicoesClimaticas,
                HistoricoIrrigacoes = p.HistoricoIrrigacoes,
                ConfiguracoesIrrigacao = p.ConfiguracoesIrrigacao,
                RegrasCondicoesClimaticas = p.RegrasCondicoesClimaticas
            });
            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var parque = await _parqueService.GetByIdAsync(id);
            if (parque == null) return NotFound();

            var viewModel = new ParqueViewModel
            {
                Id = parque.Id,
                Nome = parque.Nome,
                Localizacao = parque.Localizacao,
                Area = parque.Area,
                CondicoesClimaticas = parque.CondicoesClimaticas,
                HistoricoIrrigacoes = parque.HistoricoIrrigacoes,
                ConfiguracoesIrrigacao = parque.ConfiguracoesIrrigacao,
                RegrasCondicoesClimaticas = parque.RegrasCondicoesClimaticas
            };

            return Ok(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ParqueViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parque = new Parque
            {
                Nome = viewModel.Nome,
                Localizacao = viewModel.Localizacao,
                Ativo = viewModel.Ativo
            };

            var createdParque = await _parqueService.CreateAsync(parque);

            return CreatedAtAction(nameof(GetById), new { id = createdParque.Id }, new ParqueViewModel
            {
                Id = createdParque.Id,
                Nome = createdParque.Nome,
                Ativo = true,
                Localizacao = createdParque.Localizacao,
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParqueViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var parque = await _parqueService.GetByIdAsync(id);
            if (parque == null) return NotFound();

            parque.Nome = viewModel.Nome;
            parque.Localizacao = viewModel.Localizacao;
            parque.Ativo = viewModel.Ativo;

            await _parqueService.UpdateAsync(id,parque);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parque = await _parqueService.GetByIdAsync(id);
            if (parque == null) return NotFound();

            await _parqueService.DeleteAsync(id);

            return NoContent();
        }
    }
}
