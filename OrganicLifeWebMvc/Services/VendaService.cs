using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Data;
using OrganicLifeWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Services
{
    public class VendaService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VendaService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task InsertAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor,Cliente")] Venda venda, ApplicationUser userLogado)
        {
            if (venda.Fornecedor.Id <= 0)
            {
                venda.Fornecedor.DataHoraCadastro = DateTime.Now;
                venda.Fornecedor.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Fornecedor.Add(venda.Fornecedor);
            }
            if (venda.Cliente.Id <= 0)
            {
                venda.Cliente.DataHoraCadastro = DateTime.Now;
                venda.Cliente.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Cliente.Add(venda.Cliente);
            }
            _applicationDbContext.Venda.Add(venda);

            foreach (var produto in venda.Produtos)
            {
                _applicationDbContext.VendaProduto.Add(new VendaProduto()
                {
                    Venda = venda,
                    Produto = produto,
                    DataHoraCadastro = DateTime.Now,
                    ResponsavelCadastro = userLogado.UserName
                });
            }
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor,Cliente")] Venda venda, ApplicationUser userLogado)
        {
            bool hasAny = await _applicationDbContext.Venda.AnyAsync(an => an.Id == venda.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                venda.DataHoraAlteracao = DateTime.Now;
                venda.ResponsavelAlteracao = userLogado.UserName;
                _applicationDbContext.Update(venda);
                _applicationDbContext.Update(venda.Fornecedor);
                _applicationDbContext.Update(venda.Cliente);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task DeleteSoftAsync(Venda venda, ApplicationUser userLogado)
        {
            bool hasAny = await _applicationDbContext.Venda.AnyAsync(an => an.Id == venda.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                venda.Deletado = true;
                venda.DataHoraExclusao = DateTime.Now;
                venda.ResponsavelExclusao = userLogado.UserName;
                _applicationDbContext.Update(venda);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task<Venda> FindByIdAsync(int id)
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Where(wh => !wh.Deletado)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Venda>> FindAllAsync()
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Where(wh => !wh.Deletado)
                .ToListAsync();
        }

        public async Task<Venda> FindByIdWithAssociationAsync(int id)
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Include(ic => ic.Cliente)
                .Include(ic => ic.Cliente.Pessoa)
                .Include(ic => ic.Cliente.Pessoa.Endereco)
                .Where(wh => !wh.Deletado)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Venda>> FindAllWithAssociationAsync()
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Include(ic => ic.Cliente)
                .Include(ic => ic.Cliente.Pessoa)
                .Include(ic => ic.Cliente.Pessoa.Endereco)
                .Where(wh => !wh.Deletado)
                .ToListAsync();
        }

        public async Task<List<Venda>> FindAllWithAssociationIncludeDeletedAsync()
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Include(ic => ic.Cliente)
                .Include(ic => ic.Cliente.Pessoa)
                .Include(ic => ic.Cliente.Pessoa.Endereco)
                .ToListAsync();
        }

        public async Task<List<Venda>> FindAllWithAssociationByFornecedorAsync(int idFornecedor)
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Include(ic => ic.Cliente)
                .Include(ic => ic.Cliente.Pessoa)
                .Include(ic => ic.Cliente.Pessoa.Endereco)
                .Where(wh => !wh.Deletado && wh.Fornecedor.Id == idFornecedor)
                .ToListAsync();
        }

        public async Task<List<Venda>> FindAllWithAssociationByClienteAsync(int idCliente)
        {
            return await _applicationDbContext.Venda
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Include(ic => ic.Cliente)
                .Include(ic => ic.Cliente.Pessoa)
                .Include(ic => ic.Cliente.Pessoa.Endereco)
                .Where(wh => !wh.Deletado && wh.Cliente.Id == idCliente)
                .ToListAsync();
        }

        public async Task<bool> VendaExistAsync(int id)
        {
            return await _applicationDbContext.Venda.AnyAsync(an => an.Id == id);
        }

        public bool VendaExist(int id)
        {
            return _applicationDbContext.Venda.Any(an => an.Id == id);
        }

    }
}
