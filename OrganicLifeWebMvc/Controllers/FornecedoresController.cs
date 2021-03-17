using System.Collections.Generic;
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

        public FornecedoresController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorService.FindAllWithAssociationAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.InsertAsync(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _fornecedorService.UpdateAsync(fornecedor);
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
            var fornecedor = await _fornecedorService.FindByIdAsync(id);
            await _fornecedorService.DeleteAsync(fornecedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
