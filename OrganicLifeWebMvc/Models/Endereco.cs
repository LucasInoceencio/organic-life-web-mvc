

using Microsoft.AspNetCore.Mvc;

namespace OrganicLifeWebMvc.Models
{
    [BindProperties(SupportsGet = true)]
    public class Endereco : EntidadeBase
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public Endereco()
        {
        }

        public Endereco(string logradouro, string bairro, string numero, string cidade, string estado, string cep)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }
    }
}
