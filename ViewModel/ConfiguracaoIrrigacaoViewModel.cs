using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.ViewModel
{
    public class ConfiguracaoIrrigacaoViewModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal TemperaturaMinima { get; set; }
        public decimal TemperaturaMaxima { get; set; }
        public decimal UmidadeMinima { get; set; }
        public decimal UmidadeMaxima { get; set; }
        public bool Ativo { get; set; }

        public int ParqueId { get; set; }
        public required Parque Parque { get; set; }
    }
}
