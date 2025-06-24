namespace PatasSolidarias.Domain.Entities.Campanha;

public class ImagemEmCampanha
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Imagem { get; set; }
    public int CampanhaId { get; set; }
    
    public virtual Campanha Campanha { get; set; } = null!;
}