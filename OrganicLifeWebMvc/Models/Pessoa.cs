﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrganicLifeWebMvc.Models
{
    public class Pessoa : EntidadeBase
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Nome { get; set; }

        public string Cpf { get; set; }
        public string Rg { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [BindProperty]
        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
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
