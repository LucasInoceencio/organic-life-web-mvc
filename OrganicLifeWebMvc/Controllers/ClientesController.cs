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
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly UserService _userService;

        public ClientesController(ClienteService clienteService, UserService userService)
        {
            _clienteService = clienteService;
            _userService = userService;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            return View(await _clienteService.FindAllAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIdWithAssociationAsync((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                await _clienteService.InsertAsync(cliente, user);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            var idCliente = await _userService.IdClienteOrFornecedorByUser(user.UserName);
            if(idCliente > 0 && idCliente == id)
            {
                var clienteLogado = await _clienteService.FindByIdWithAssociationAsync((int)id);
                if (clienteLogado == null)
                {
                    return NotFound();
                }
                return View(clienteLogado);
            }

            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIdWithAssociationAsync((int)id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,Pessoa")] Cliente cliente)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            var idCliente = await _userService.IdClienteOrFornecedorByUser(user.UserName);

            if(idCliente != id)
                if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                    return RedirectToAction("Index", "Home");

            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.UpdateAsync(cliente, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var clienteExist = await _clienteService.ClienteExistAsync(cliente.Id);
                    if (!clienteExist)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.FindByIdAsync((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            var cliente = await _clienteService.FindByIdAsync((int)id);
            await _clienteService.DeleteAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
