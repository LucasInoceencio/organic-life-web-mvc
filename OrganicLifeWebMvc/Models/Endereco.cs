

namespace OrganicLifeWebMvc.Models
{
    public class Endereco : EntidadeBase
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
