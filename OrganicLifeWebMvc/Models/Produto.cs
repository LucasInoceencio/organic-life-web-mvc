
namespace OrganicLifeWebMvc.Models
{
    public enum CategoriaProduto
    {
        Verdura = 1,
        Legume = 2,
        Fruta = 3
    }

    public class Produto : EntidadeSoftDelete
    {
        public Fornecedor Fornecedor { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public bool Organico { get; set; }

        public Produto()
        {
        }

        public Produto(Fornecedor fornecedor, string sigla, string nome, string descricao, double valor, CategoriaProduto categoria, bool organico)
        {
            Fornecedor = fornecedor;
            Sigla = sigla;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Categoria = categoria;
            Organico = organico;
        }
    }
}
