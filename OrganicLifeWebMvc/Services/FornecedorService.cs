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
    public class FornecedorService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FornecedorService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Fornecedor> GetFornecedorByUser(ApplicationUser user)
        {
            if(user == null || user.Pessoa == null || user.Pessoa.Id <= 0)
                throw new NotFoundException("Id not found!");

            var result = await _applicationDbContext.Fornecedor
                .Include(ic => ic.PessoaJuridica)
                .Include(ic => ic.PessoaJuridica.Endereco)
                .Include(ic => ic.PessoaJuridica.Responsavel)
                .ToListAsync();
            return result.Where(wh => wh.PessoaJuridica.Responsavel.Id == user.Pessoa.Id).FirstOrDefault();
        }

        public async Task InsertAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,PessoaJuridica,Endereco")] Fornecedor fornecedor, ApplicationUser userLogado)
        {
            fornecedor.DataHoraCadastro = DateTime.Now;
            fornecedor.ResponsavelCadastro = userLogado.UserName;
            if (fornecedor.PessoaJuridica.Id <= 0)
            {
                fornecedor.PessoaJuridica.Responsavel.DataHoraCadastro = DateTime.Now;
                fornecedor.PessoaJuridica.Responsavel.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Pessoa.Add(fornecedor.PessoaJuridica.Responsavel);
            }
            if (fornecedor.PessoaJuridica.Id <= 0)
            {
                fornecedor.PessoaJuridica.DataHoraCadastro = DateTime.Now;
                fornecedor.PessoaJuridica.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.PessoaJuridica.Add(fornecedor.PessoaJuridica);
            }
            if (fornecedor.PessoaJuridica.Endereco.Id <= 0)
            {
                fornecedor.PessoaJuridica.Endereco.DataHoraCadastro = DateTime.Now;
                fornecedor.PessoaJuridica.Endereco.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Endereco.Add(fornecedor.PessoaJuridica.Endereco);
            }
            if (fornecedor.PessoaJuridica.Endereco.Id <= 0)
            {
                fornecedor.PessoaJuridica.Responsavel.Endereco.DataHoraCadastro = DateTime.Now;
                fornecedor.PessoaJuridica.Responsavel.Endereco.ResponsavelCadastro = userLogado.UserName;
                _applicationDbContext.Endereco.Add(fornecedor.PessoaJuridica.Responsavel.Endereco);
            }
            _applicationDbContext.Fornecedor.Add(fornecedor);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,PessoaJuridica,Endereco")] Fornecedor fornecedor, ApplicationUser userLogado)
        {
            bool hasAny = await _applicationDbContext.Fornecedor.AnyAsync(an => an.Id == fornecedor.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                fornecedor.DataHoraAlteracao = DateTime.Now;
                fornecedor.ResponsavelAlteracao = userLogado.UserName;
                fornecedor.PessoaJuridica.Responsavel.DataHoraAlteracao = DateTime.Now;
                fornecedor.PessoaJuridica.Responsavel.ResponsavelAlteracao = userLogado.UserName;
                fornecedor.PessoaJuridica.DataHoraAlteracao = DateTime.Now;
                fornecedor.PessoaJuridica.ResponsavelAlteracao = userLogado.UserName;
                fornecedor.PessoaJuridica.Endereco.DataHoraAlteracao = DateTime.Now;
                fornecedor.PessoaJuridica.Endereco.ResponsavelAlteracao = userLogado.UserName;
                fornecedor.PessoaJuridica.Responsavel.Endereco.DataHoraAlteracao = DateTime.Now;
                fornecedor.PessoaJuridica.Responsavel.Endereco.ResponsavelAlteracao = userLogado.UserName;

                _applicationDbContext.Update(fornecedor);
                _applicationDbContext.Update(fornecedor.PessoaJuridica);
                _applicationDbContext.Update(fornecedor.PessoaJuridica.Endereco);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task DeleteAsync(Fornecedor fornecedor)
        {
            try
            {
                var seller = await this.FindByIdAsync(fornecedor.Id);
                _applicationDbContext.Fornecedor.Remove(seller);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete supplier because he/se has sales.");
            }
        }

        public async Task<Fornecedor> FindByIdAsync(int id)
        {
            return await _applicationDbContext.Fornecedor
                .Include(ic => ic.PessoaJuridica)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Fornecedor>> FindAllAsync()
        {
            return await _applicationDbContext.Fornecedor
                .Include(ic => ic.PessoaJuridica)
                .ToListAsync();
        }

        public async Task<Fornecedor> FindByIdWithAssociationAsync(int id)
        {
            return await _applicationDbContext.Fornecedor
                .Include(ic => ic.PessoaJuridica)
                .Include(ic => ic.PessoaJuridica.Endereco)
                .Include(ic => ic.PessoaJuridica.Responsavel)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Fornecedor>> FindAllWithAssociationAsync()
        {
            var result = await _applicationDbContext.Fornecedor
                .Include(ic => ic.PessoaJuridica)
                .Include(ic => ic.PessoaJuridica.Endereco)
                .Include(ic => ic.PessoaJuridica.Responsavel)
                .ToListAsync();

            return result;
        }

        public async Task<bool> FornecedorExistAsync(int id)
        {
            return await _applicationDbContext.Fornecedor.AnyAsync(an => an.Id == id);
        }

        public bool FornecedorExist(int id)
        {
            return _applicationDbContext.Fornecedor.Any(an => an.Id == id);
        }
    }
}
