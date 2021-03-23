
namespace OrganicLifeWebMvc.Models
{
    public class VendaProduto : EntidadeBase
    {
        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}
