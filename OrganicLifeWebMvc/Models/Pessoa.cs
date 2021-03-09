using System;

namespace OrganicLifeWebMvc.Models
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(string nome, string cpf, string rg, DateTime dataNascimento, Endereco endereco, string email, string telefone, string celular)
        {
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Celular = celular;
        }
    }
}
