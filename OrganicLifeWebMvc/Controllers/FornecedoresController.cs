﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Models;
using OrganicLifeWebMvc.Services;

namespace OrganicLifeWebMvc.Views
{
    public class FornecedoresController : Controller
    {
        private readonly FornecedorService _fornecedorService;
        private readonly UserService _userService;

        public FornecedoresController(FornecedorService fornecedorService, UserService userService)
        {
            _fornecedorService = fornecedorService;
            _userService = userService;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            return View(await _fornecedorService.FindAllWithAssociationAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.FindByIdWithAssociationAsync((int)id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public async Task<IActionResult> Create()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,PessoaJuridica")] Fornecedor fornecedor)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                await _fornecedorService.InsertAsync(fornecedor, user);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);

            var idFornecedor = await _userService.IdClienteOrFornecedorByUser(user.UserName);
            if (idFornecedor > 0 && idFornecedor == id)
            {
                var fornecedorLogado = await _fornecedorService.FindByIdWithAssociationAsync((int)id);
                if (fornecedorLogado == null)
                {
                    return NotFound();
                }
                return View(fornecedorLogado);
            }

            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.FindByIdWithAssociationAsync((int)id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao,PessoaJuridica")]Fornecedor fornecedor)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            var idFornecedor = await _userService.IdClienteOrFornecedorByUser(user.UserName);
            if(idFornecedor != id)
                if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                    return RedirectToAction("Index", "Home");

            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fornecedorAtual = await _fornecedorService.FindByIdWithAssociationAsync(fornecedor.Id);
                    fornecedorAtual.PessoaJuridica.NomeFantasia = fornecedor.PessoaJuridica.NomeFantasia;
                    fornecedorAtual.PessoaJuridica.RazaoSocial = fornecedor.PessoaJuridica.RazaoSocial;
                    fornecedorAtual.PessoaJuridica.Cnpj = fornecedor.PessoaJuridica.Cnpj;
                    fornecedorAtual.PessoaJuridica.Celular = fornecedor.PessoaJuridica.Celular;
                    fornecedorAtual.PessoaJuridica.Telefone = fornecedor.PessoaJuridica.Telefone;
                    fornecedorAtual.PessoaJuridica.Email = fornecedor.PessoaJuridica.Email;
                    await _fornecedorService.UpdateAsync(fornecedorAtual, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var fornecedorExist = await _fornecedorService.FornecedorExistAsync(fornecedor.Id);
                    if (!fornecedorExist)
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
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.FindByIdAsync((int)id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if (user == null || user.TipoUsuario.ToLower().Equals("fornecedor") || user.TipoUsuario.ToLower().Equals("cliente"))
                return RedirectToAction("Index", "Home");

            var fornecedor = await _fornecedorService.FindByIdAsync(id);
            await _fornecedorService.DeleteAsync(fornecedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
