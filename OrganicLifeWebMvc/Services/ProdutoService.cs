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
    public class ProdutoService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProdutoService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task InsertAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor")] Produto produto, ApplicationUser userLogado)
        {
            produto.DataHoraCadastro = DateTime.Now;
            produto.ResponsavelCadastro = userLogado.UserName;
            if (produto.Fornecedor.Id <= 0)
            {
                produto.Fornecedor.DataHoraCadastro = DateTime.Now;
                produto.Fornecedor.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Fornecedor.Add(produto.Fornecedor);
            }
            _applicationDbContext.Produto.Add(produto);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor")] Produto produto, ApplicationUser userLogado)
        {
            bool hasAny = await _applicationDbContext.Produto.AnyAsync(an => an.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                produto.DataHoraAlteracao = DateTime.Now;
                produto.ResponsavelAlteracao = userLogado.UserName;
                _applicationDbContext.Update(produto);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task DeleteSoftAsync(Produto produto, ApplicationUser userLogado)
        {
            bool hasAny = await _applicationDbContext.Produto.AnyAsync(an => an.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                produto.Deletado = true;
                produto.DataHoraExclusao = DateTime.Now;
                produto.ResponsavelExclusao = userLogado.UserName;
                _applicationDbContext.Update(produto);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Where(wh => !wh.Deletado)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Where(wh => !wh.Deletado)
                .ToListAsync();
        }

        public async Task<Produto> FindByIdWithAssociationAsync(int id)
        {
            return await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Where(wh => !wh.Deletado)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Produto>> FindAllWithAssociationAsync()
        {
            return await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .Where(wh => !wh.Deletado)
                .ToListAsync();
        }

        public async Task<List<Produto>> FindAllWithAssociationIncludeDeletedAsync()
        {
            return await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .ToListAsync();
        }

        public async Task<bool> ProdutoExistAsync(int id)
        {
            return await _applicationDbContext.Produto.AnyAsync(an => an.Id == id);
        }

        public bool ProdutoExist(int id)
        {
            return _applicationDbContext.Produto.Any(an => an.Id == id);
        }

        public async Task<List<Produto>> FindAllWithAssociationByFornecedor(int idFornecedor)
        {
            var result = await _applicationDbContext.Produto
                .Include(ic => ic.Fornecedor)
                .Include(ic => ic.Fornecedor.PessoaJuridica)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Endereco)
                .Include(ic => ic.Fornecedor.PessoaJuridica.Responsavel)
                .ToListAsync();

            result = result.Where(wh => wh.Fornecedor.Id == idFornecedor && !wh.Deletado).ToList();
            return result;
        }
    }
}
