namespace MonitoramentoAmbiental.ViewModel
{
    public class HistoricoIrrigacaoViewModel
    {
        public int Id { get; set; }
        public int ConfiguracaoIrrigacaoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
