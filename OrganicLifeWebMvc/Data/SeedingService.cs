using OrganicLifeWebMvc.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OrganicLifeWebMvc.Data
{
    public class SeedingService
    {
        private ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Pessoa.Any() || _context.Endereco.Any() || _context.Produto.Any())
            {
                return;
            }

            // Endereço
            var endereco1 = new Endereco() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Rua 25, Ad 02, Lt 09", Bairro = "Boa Vista", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "10" };
            var endereco2 = new Endereco() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Rua 45 Qd 09", Bairro = "Jardim Prive", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "156" };
            var endereco3 = new Endereco() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Rua C Qd 28 Lt 13", Bairro = "Turista I", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "678" };
            var endereco4 = new Endereco() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Avenida das Araras", Bairro = "Itanhangá II", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "09" };
            var endereco5 = new Endereco() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Alameda dos Turistas, Lt 78", Bairro = "Holliday", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "34" };
            var endereco6 = new Endereco() { Id = 6, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Go 139", Bairro = "SetorLago Sul", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "56" };
            var endereco7 = new Endereco() { Id = 7, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Debaixo da ponte", Bairro = "Morada Nobre", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "67" };
            var endereco8 = new Endereco() { Id = 8, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Beco dos macacos", Bairro = "Centro", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "178" };
            var endereco9 = new Endereco() { Id = 9, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Praça dos carotes", Bairro = "Caminho do Lago", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "00" };
            var endereco10 = new Endereco() { Id = 10, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Logradouro = "Fonte das águas termais", Bairro = "Bandeirantes", Cep = "75690000", Cidade = "Caldas Novas", Estado = "Goiás", Numero = "S/N" };

            // Pessoa cliente
            var pessoa1 = new Pessoa() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Alfredo Gusmao", Cpf = "767.499.600-06", Rg = "24.444.189-3", DataNascimento = new DateTime(1990, 09, 08), Endereco = endereco1, Email = "alfredo@gmail.com", Celular = "6492224546" };
            var pessoa2 = new Pessoa() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Marinalda Silva", Cpf = "023.788.920-04", Rg = "46.639.606-5", DataNascimento = new DateTime(1995, 05, 05), Endereco = endereco2, Email = "marinalda@gmail.com", Celular = "6492224532" };
            var pessoa3 = new Pessoa() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Antonio Fagundes", Cpf = "983.738.170-18", Rg = "25.784.575-6", DataNascimento = new DateTime(1976, 04, 12), Endereco = endereco3, Email = "antonio@gmail.com", Celular = "6497826785" };
            var pessoa4 = new Pessoa() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Marcela Faria", Cpf = "520.142.470-80", Rg = "50.537.677-5", DataNascimento = new DateTime(1967, 12, 28), Endereco = endereco4, Email = "marcela@gmail.com", Celular = "6492095678" };
            var pessoa5 = new Pessoa() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Luana Andrade", Cpf = "111.655.240-07", Rg = "49.103.012-5", DataNascimento = new DateTime(1989, 11, 22), Endereco = endereco5, Email = "luanaandrade@gmail.com", Celular = "6492238909" };

            // Pessoa fornecedor
            var pessoa6 = new Pessoa() { Id = 6, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Melissa Viana", Cpf = "332.588.350-80", Rg = "47.100.217-3", DataNascimento = new DateTime(1994, 04, 19), Endereco = endereco6, Email = "melissa@gmail.com", Celular = "6492456789" };
            var pessoa7 = new Pessoa() { Id = 7, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Grazielle Freitas", Cpf = "717.860.530-80", Rg = "21.992.722-4", DataNascimento = new DateTime(1987, 01, 30), Endereco = endereco7, Email = "grazielle@gmail.com", Celular = "6492097865" };
            var pessoa8 = new Pessoa() { Id = 8, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Milionário", Cpf = "312.017.060-76", Rg = "12.906.780-5", DataNascimento = new DateTime(1966, 10, 31), Endereco = endereco8, Email = "milionario@gmail.com", Celular = "6492234565" };
            var pessoa9 = new Pessoa() { Id = 9, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "José Rico", Cpf = "939.085.260-94", Rg = "22.259.759-8", DataNascimento = new DateTime(1978, 09, 13), Endereco = endereco9, Email = "joserico@gmail.com", Celular = "6492234561" };
            var pessoa10 = new Pessoa() { Id = 10, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Nome = "Vintage Culture", Cpf = "996.754.460-05", Rg = "27.653.523-6", DataNascimento = new DateTime(1987, 10, 01), Endereco = endereco10, Email = "vintage@gmail.com", Celular = "6492785643" };

            // Pessoa Jurídica
            var pj1 = new PessoaJuridica() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", RazaoSocial = "Verdura e cia me", NomeFantasia = "Verdurao dolores", Cnpj = "47.178.740/0001-86", Responsavel = pessoa6, Endereco = endereco6, Email = "verduraodolores@gmail.com", Telefone = "6434567897" };
            var pj2 = new PessoaJuridica() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", RazaoSocial = "Verdurao abc ltda", NomeFantasia = "Verdurao ABC", Cnpj = "56.639.148/0001-25", Responsavel = pessoa7, Endereco = endereco7, Email = "verduraabc@gmail.com", Telefone = "6434537865" };
            var pj3 = new PessoaJuridica() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", RazaoSocial = "Ze maria verduras ltda", NomeFantasia = "Verduras do Zé Maria", Cnpj = "13.183.726/0001-59", Responsavel = pessoa8, Endereco = endereco8, Email = "verduraszemaria@gmail.com", Telefone = "6434556798" };
            var pj4 = new PessoaJuridica() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", RazaoSocial = "Frutas e cia me", NomeFantasia = "Frutas e cia", Cnpj = "42.099.378/0001-34", Responsavel = pessoa9, Endereco = endereco9, Email = "frutasecia@gmail.com", Telefone = "6434559078" };
            var pj5 = new PessoaJuridica() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", RazaoSocial = "Xepa verduras ltda", NomeFantasia = "Xepa das Verduras", Cnpj = "75.769.639/0001-35", Responsavel = pessoa10, Endereco = endereco10, Email = "xepadasverduras@gmail.com", Telefone = "6434531232" };

            // Cliente
            var cliente1 = new Cliente() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Pessoa = pessoa1 };
            var cliente2 = new Cliente() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Pessoa = pessoa2 };
            var cliente3 = new Cliente() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Pessoa = pessoa3 };
            var cliente4 = new Cliente() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Pessoa = pessoa4 };
            var cliente5 = new Cliente() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Pessoa = pessoa5 };

            // Fornecedor
            var fornecedor1 = new Fornecedor() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", PessoaJuridica = pj1};
            var fornecedor2 = new Fornecedor() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", PessoaJuridica = pj2};
            var fornecedor3 = new Fornecedor() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", PessoaJuridica = pj3};
            var fornecedor4 = new Fornecedor() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", PessoaJuridica = pj4};
            var fornecedor5 = new Fornecedor() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", PessoaJuridica = pj5};

            // Produto 
            var produto1 = new Produto() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor1, Sigla = "ABAX", Nome = "Abacaxi", Descricao = "Abacaxi da terra", Categoria = CategoriaProduto.Fruta, Organico = true, Valor = 3.99 };
            var produto2 = new Produto() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor1, Sigla = "ALFC", Nome = "Alface", Descricao = "Alface americana", Categoria = CategoriaProduto.Verdura, Organico = true, Valor = 2.99 };
            var produto3 = new Produto() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor1, Sigla = "TMT", Nome = "Tomate", Descricao = "Tomate de verdade", Categoria = CategoriaProduto.Legume, Organico = true, Valor = 8.48 };
            var produto4 = new Produto() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor2, Sigla = "MEL", Nome = "Melão", Descricao = "Melão dos bão", Categoria = CategoriaProduto.Fruta, Organico = true, Valor = 7.99 };
            var produto5 = new Produto() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor2, Sigla = "ALFC", Nome = "Couve", Descricao = "Couve rico em ferro", Categoria = CategoriaProduto.Verdura, Organico = false, Valor = 4.95 };
            var produto6 = new Produto() { Id = 6, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor2, Sigla = "ABB", Nome = "Abobrinha", Descricao = "Abobrinha verde", Categoria = CategoriaProduto.Legume, Organico = true, Valor = 7.78 };
            var produto7 = new Produto() { Id = 7, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor3, Sigla = "LARJ", Nome = "Laranja", Descricao = "Laranja da boa", Categoria = CategoriaProduto.Fruta, Organico = false, Valor = 3.99 };
            var produto8 = new Produto() { Id = 8, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor3, Sigla = "ALFC", Nome = "Repolho", Descricao = "Repolho pra salada", Categoria = CategoriaProduto.Verdura, Organico = true, Valor = 5.99 };
            var produto9 = new Produto() { Id = 9, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor3, Sigla = "TMT", Nome = "Chuchu", Descricao = "Chuchus", Categoria = CategoriaProduto.Legume, Organico = true, Valor = 4.45 };
            var produto10 = new Produto() { Id = 10, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor4, Sigla = "MELC", Nome = "Melancia", Descricao = "Melancia pra família inteira", Categoria = CategoriaProduto.Fruta, Organico = true, Valor = 3.99 };
            var produto11 = new Produto() { Id = 11, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor4, Sigla = "ALFC", Nome = "Alface", Descricao = "Alface lisa", Categoria = CategoriaProduto.Verdura, Organico = false, Valor = 6.78 };
            var produto12 = new Produto() { Id = 12, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor4, Sigla = "TMT", Nome = "Pimentão", Descricao = "Pimentão verde", Categoria = CategoriaProduto.Legume, Organico = false, Valor = 6.43 };
            var produto13 = new Produto() { Id = 13, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor5, Sigla = "ABAX", Nome = "Abacaxi", Descricao = "Abacaxi da terra", Categoria = CategoriaProduto.Fruta, Organico = false, Valor = 2.99 };
            var produto14 = new Produto() { Id = 14, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor5, Sigla = "SALS", Nome = "Salsa", Descricao = "Salsa pra temperar", Categoria = CategoriaProduto.Verdura, Organico = false, Valor = 4.25 };
            var produto15 = new Produto() { Id = 15, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Fornecedor = fornecedor5, Sigla = "PPN", Nome = "Pepino", Descricao = "Pepino japonês", Categoria = CategoriaProduto.Legume, Organico = true, Valor = 12.23 };

            // Venda

            var venda1 = new Venda() { Id = 1, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Cliente = cliente1, Fornecedor = fornecedor1, MeioPagamento = MeioPagamento.CartaoCredito, Pago = true, TaxaEntrega = 5.00, ValorDesconto = 2.00 };
            venda1.AddProduto(produto1);
            venda1.AddProduto(produto2);

            var venda2 = new Venda() { Id = 2, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Cliente = cliente2, Fornecedor = fornecedor3, MeioPagamento = MeioPagamento.Dinheiro, Pago = true, TaxaEntrega = 6.00, ValorDesconto = 3.00 };
            venda2.AddProduto(produto7);
            venda2.AddProduto(produto9);

            var venda3 = new Venda() { Id = 3, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Cliente = cliente3, Fornecedor = fornecedor4, MeioPagamento = MeioPagamento.Cheque, Pago = false, TaxaEntrega = 7.00, ValorDesconto = 5.00 };
            venda3.AddProduto(produto10);
            venda3.AddProduto(produto12);

            var venda4 = new Venda() { Id = 4, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Cliente = cliente4, Fornecedor = fornecedor5, MeioPagamento = MeioPagamento.Pix, Pago = true, TaxaEntrega = 4.00, ValorDesconto = 2.00 };
            venda4.AddProduto(produto14);
            venda4.AddProduto(produto15);

            var venda5 = new Venda() { Id = 5, DataHoraCadastro = DateTime.Now, ResponsavelCadastro = "Inocencio", Cliente = cliente5, Fornecedor = fornecedor2, MeioPagamento = MeioPagamento.Transferencia, Pago = false, TaxaEntrega = 8.00, ValorDesconto = 1.00 };
            venda5.AddProduto(produto4);
            venda5.AddProduto(produto5);

            // Add no banco
            _context.Endereco.AddRange(endereco1, endereco2, endereco3, endereco4, endereco5, endereco6, endereco7, endereco8, endereco9, endereco10);

            _context.Pessoa.AddRange(pessoa1, pessoa2, pessoa3, pessoa4, pessoa5, pessoa6, pessoa7, pessoa8, pessoa9, pessoa10);

            _context.PessoaJuridica.AddRange(pj1, pj2, pj3, pj4, pj5);

            _context.Cliente.AddRange(cliente1, cliente2, cliente3, cliente4, cliente5);

            _context.Fornecedor.AddRange(fornecedor1, fornecedor2, fornecedor3, fornecedor4, fornecedor5);

            _context.Produto.AddRange(produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8, produto9, produto10, produto11, produto12, produto13, produto14, produto15);

            _context.Venda.AddRange(venda1, venda2, venda3, venda4, venda5);

            _context.SaveChanges();
        }
    }
}
