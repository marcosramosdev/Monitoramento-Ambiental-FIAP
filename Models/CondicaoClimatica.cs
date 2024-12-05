namespace MonitoramentoAmbiental.Models
{
    public class CondicaoClimatica
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Temperatura { get; set; }
        public decimal Umidade { get; set; }
        public required string Descricao { get; set; }

        public int ParqueId { get; set; }
        public required Parque Parque { get; set; }
    }
}
