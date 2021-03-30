using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Data;
using OrganicLifeWebMvc.Models;
using OrganicLifeWebMvc.Services;

namespace OrganicLifeWebMvc.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly VendaService _vendaService;
        private readonly UserService _userService;
        private readonly FornecedorService _fornecedorService;
        private readonly ClienteService _clienteService;

        public RelatoriosController(VendaService vendaService, UserService userService, FornecedorService fornecedorService, ClienteService clienteService)
        {
            _vendaService = vendaService;
            _userService = userService;
            _fornecedorService = fornecedorService;
            _clienteService = clienteService;
        }

        // GET: RelatoriosVendas
        public async Task<IActionResult> RelatorioVendas()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            var fornecedor = _fornecedorService.GetFornecedorByUser(user);

            return View(await _vendaService.FindAllWithAssociationByFornecedorAsync(fornecedor.Id));
        }

        // GET: RelatoriosCompras
        public async Task<IActionResult> RelatorioCompras()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor"))
                return RedirectToAction("Index", "Home");

            var cliente = _clienteService.GetClienteByUser(user);

            return View(await _vendaService.FindAllWithAssociationByClienteAsync(cliente.Id));
        }
    }
}
