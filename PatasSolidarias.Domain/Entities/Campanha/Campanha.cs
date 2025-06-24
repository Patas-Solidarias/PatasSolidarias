using PatasSolidarias.Domain.Entities.Doacoes;

namespace PatasSolidarias.Domain.Entities.Campanha;

public class Campanha {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set;}
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public DateTime DataProgressao { get; set; } 
    public decimal MetaArrecadacao { get; set; }
    public decimal Progresso { get; set; }
    public int OngUsuarioId { get; set; }
    
    public virtual Usuario? OngUsuario { get; set; }
    public ICollection<Doacao> Doacoes { get; private set; } = [];
    public ICollection<ImagemEmCampanha> Imagens { get; private set; } = [];
}