namespace MonitoramentoAmbiental.Models
{
    public class Parque
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public decimal Area { get; set; }
        public bool Ativo { get; set; }
        public ICollection<CondicaoClimatica> CondicoesClimaticas { get; set; }
        public ICollection<HistoricoIrrigacao> HistoricoIrrigacoes { get; set; }
        public ICollection<ConfiguracaoIrrigacao> ConfiguracoesIrrigacao { get; set; }
        public ICollection<RegraCondicaoClimatica> RegrasCondicoesClimaticas { get; set; }
    }



}
