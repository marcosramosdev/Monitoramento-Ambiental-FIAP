namespace MonitoramentoAmbiental.Models
{
    public class RegraCondicaoClimatica
    {
        public required int Id { get; set; }
        public required string Descricao { get; set; }
        public required bool Ativo { get; set; }
        public float? TemperaturaMinima { get; set; }
        public float? TemperaturaMaxima { get; set; }
        public float? UmidadeMinima { get; set; }
        public float? UmidadeMaxima { get; set; }
        public required int ParqueId { get; set; }
        public required Parque Parque { get; set; }
    }
}
