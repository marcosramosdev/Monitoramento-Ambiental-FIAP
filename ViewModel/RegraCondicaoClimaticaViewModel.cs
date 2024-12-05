namespace MonitoramentoAmbiental.ViewModel
{
    public class RegraCondicaoClimaticaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public double TemperaturaMinima { get; set; }
        public double TemperaturaMaxima { get; set; }
        public int ParqueId { get; set; }
    }
}
