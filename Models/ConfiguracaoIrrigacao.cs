using MonitoramentoAmbiental.Models;

public class ConfiguracaoIrrigacao
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
    public decimal Intervalo { get; set; } // Adicionando a propriedade Intervalo
    public object? Duracao { get; internal set; }
}
