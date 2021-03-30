using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Data;
using OrganicLifeWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Services
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClienteService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Cliente> GetClienteByUser(ApplicationUser user)
        {
            if (user == null || user.Pessoa == null || user.Pessoa.Id <= 0)
                throw new NotFoundException("Id not found!");

            var result = await _applicationDbContext.Cliente
                .Include(ic => ic.Pessoa)
                .ToListAsync();
            return result.Where(wh => wh.Pessoa.Id == user.Pessoa.Id).FirstOrDefault();
        }

        public async Task InsertAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Pessoa,Endereco")] Cliente cliente)
        {
            _applicationDbContext.Cliente.Add(cliente);
            _applicationDbContext.Pessoa.Add(cliente.Pessoa);
            _applicationDbContext.Endereco.Add(cliente.Pessoa.Endereco);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Pessoa,Endereco")] Cliente cliente)
        {
            bool hasAny = await _applicationDbContext.Cliente.AnyAsync(an => an.Id == cliente.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _applicationDbContext.Update(cliente);
                _applicationDbContext.Update(cliente.Pessoa);
                _applicationDbContext.Update(cliente.Pessoa);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            try
            {
                var seller = await this.FindByIdAsync(cliente.Id);
                _applicationDbContext.Cliente.Remove(seller);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete customer because he/se has sales.");
            }
        }

        public async Task<Cliente> FindByIdAsync(int id)
        {
            return await _applicationDbContext.Cliente
                .Include(ic => ic.Pessoa)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Cliente>> FindAllAsync()
        {
            return await _applicationDbContext.Cliente
                .Include(ic => ic.Pessoa)
                .ToListAsync();
        }

        public async Task<Cliente> FindByIdWithAssociationAsync(int id)
        {
            return await _applicationDbContext.Cliente
                .Include(ic => ic.Pessoa)
                .Include(ic => ic.Pessoa.Endereco)
                .SingleOrDefaultAsync(sg => sg.Id == id);
        }

        public async Task<List<Cliente>> FindAllWithAssociationAsync()
        {
            return await _applicationDbContext.Cliente
                .Include(ic => ic.Pessoa)
                .Include(ic => ic.Pessoa.Endereco)
                .ToListAsync();
        }

        public async Task<bool> ClienteExistAsync(int id)
        {
            return await _applicationDbContext.Cliente.AnyAsync(an => an.Id == id);
        }

        public bool ClienteExist(int id)
        {
            return _applicationDbContext.Cliente.Any(an => an.Id == id);
        }
    }
}
