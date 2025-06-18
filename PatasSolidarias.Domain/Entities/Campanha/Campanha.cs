using PatasSolidarias.Domain.Entities.Doacoes;

namespace PatasSolidarias.Domain.Entities.Campanha;

public sealed class Campanha{
    public int ID { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set;}
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }
    public DateTime DataProgressao { get; private set; } 
    public decimal MetaArrecadacao { get; private set; }
    public decimal Progresso { get; private set;}
    public int IdOng { get; private set;}
    public ICollection<Doacao> Doacoes { get; private set; } = [];


    private Campanha() { }

    public Campanha( string titulo, 
                     string descricao,
                     DateTime dataInicio,
                     DateTime dataFim,
                     DateTime dataProgressao,
                     decimal metaArrecadacao,
                     decimal progresso,
                     int idOng) 
    {
        titulo = Titulo;
        descricao = Descricao;
        dataInicio = DataInicio;
        dataFim = DataFim;
        dataProgressao = DataProgressao;
        metaArrecadacao = MetaArrecadacao;
        progresso = Progresso;
        idOng = IdOng;
    }
}