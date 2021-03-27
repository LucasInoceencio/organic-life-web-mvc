using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Models;
using OrganicLifeWebMvc.Services;

namespace OrganicLifeWebMvc.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendaService _vendaService;
        private readonly FornecedorService _fornecedorService;

        public VendasController(VendaService vendaService, FornecedorService fornecedorService)
        {
            _vendaService = vendaService;
            _fornecedorService = fornecedorService;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorService.FindAllWithAssociationAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.FindByIdWithAssociationAsync((int)id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ValorTotal,ValorDesconto,TaxaEntrega,MeioPagamento,Pago,DataHoraPrevisaoEntrega,Deletado,DataHoraExclusao,ResponsavelExclusao,Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                await _vendaService.InsertAsync(venda);
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.FindByIdWithAssociationAsync((int)id);
            if (venda == null)
            {
                return NotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ValorTotal,ValorDesconto,TaxaEntrega,MeioPagamento,Pago,DataHoraPrevisaoEntrega,Deletado,DataHoraExclusao,ResponsavelExclusao,Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vendaService.UpdateAsync(venda);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var vendaExist = await _vendaService.VendaExistAsync(venda.Id);
                    if (!vendaExist)
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
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.FindByIdWithAssociationAsync((int)id);

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _vendaService.FindByIdWithAssociationAsync(id);
            await _vendaService.DeleteSoftAsync(venda);
            return RedirectToAction(nameof(Index));
        }
    }
}
