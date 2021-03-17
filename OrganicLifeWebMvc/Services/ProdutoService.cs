using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Data;
using OrganicLifeWebMvc.Models;
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

        public async Task InsertAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor")] Produto produto)
        {
            _applicationDbContext.Produto.Add(produto);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Fornecedor")] Produto produto)
        {
            bool hasAny = await _applicationDbContext.Produto.AnyAsync(an => an.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _applicationDbContext.Update(produto);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task DeleteSoftAsync(Produto produto)
        {
            bool hasAny = await _applicationDbContext.Produto.AnyAsync(an => an.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                produto.Deletado = true;
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
    }
}
