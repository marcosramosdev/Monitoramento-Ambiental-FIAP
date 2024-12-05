namespace MonitoramentoAmbiental.Models
{
    public class HistoricoIrrigacao
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public decimal VolumeIrrigado { get; set; }
        public int ParqueId { get; set; }
        public required Parque Parque { get; set; }
        public int ConfiguracaoIrrigacaoId { get; set; }
        public required ConfiguracaoIrrigacao ConfiguracaoIrrigacao { get; set; } 
    }
}