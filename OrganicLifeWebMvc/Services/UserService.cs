using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Data;
using OrganicLifeWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicLifeWebMvc.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ApplicationUser> GetUserByName(string name)
        {
            //var login = User.Identity.Name;
            var user = await _applicationDbContext.Users.Where(wh => wh.UserName.Equals(name)).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> UserIsCliente(string idUser)
        {
            if (string.IsNullOrWhiteSpace(idUser))
                return false;

            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(sg => sg.UserName == idUser);
            if (user == null)
                return false;

            if (user.TipoUsuario.ToLower().Equals("cliente"))
                return true;

            return false;
        }

        public async Task<bool> UserIsFornecedor(string idUser)
        {
            if (string.IsNullOrWhiteSpace(idUser))
                return false;

            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(sg => sg.UserName == idUser);
            if (user == null)
                return false;

            if (user.TipoUsuario.ToLower().Equals("fornecedor"))
                return true;

            return false;
        }

        public async Task<bool> UserIsAdmin(string idUser)
        {
            if (string.IsNullOrWhiteSpace(idUser))
                return false;

            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(sg => sg.UserName == idUser);
            if (user == null)
                return false;

            if (user.TipoUsuario.ToLower().Equals("admin"))
                return true;

            return false;
        }

        public async Task<string> TypeUser(string idUser)
        {
            if (string.IsNullOrWhiteSpace(idUser))
                return "";

            var user = await _applicationDbContext.Users.SingleOrDefaultAsync(sg => sg.UserName == idUser);
            if (user == null)
                return "";

            return user.TipoUsuario;
        }
    }
}
