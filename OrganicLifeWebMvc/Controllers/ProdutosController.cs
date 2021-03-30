using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicLifeWebMvc.Controllers;
using OrganicLifeWebMvc.Models;
using OrganicLifeWebMvc.Services;

namespace OrganicLifeWebMvc.Views
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly UserService _userService;

        public ProdutosController(ProdutoService context, UserService userService)
        {
            _produtoService = context;
            _userService = userService;
        }

        private async Task<bool> ValidarUsuario()
        {
            var user = await _userService.GetUserByName(User.Identity.Name);
            if(user == null)
                return false;

            if (user.TipoUsuario.ToLower().Equals("admin") || user.TipoUsuario.ToLower().Equals("fornecedor"))
                return true;

            return false;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            if(await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            return View(await _produtoService.FindAllWithAssociationAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIdWithAssociationAsync((int)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sigla,Nome,Descricao,Valor,Categoria,Organico,Deletado,DataHoraExclusao,ResponsavelExclusao,Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Produto produto)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                await _produtoService.InsertAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIdWithAssociationAsync((int)id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sigla,Nome,Descricao,Valor,Categoria,Organico,Deletado,DataHoraExclusao,ResponsavelExclusao,Id,DataHoraCadastro,ResponsavelCadastro,DataHoraAlteracao,ResponsavelAlteracao")] Produto produto)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoService.UpdateAsync(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var produtoExist = await _produtoService.ProdutoExistAsync(produto.Id);
                    if (!produtoExist)
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIdWithAssociationAsync((int)id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await ValidarUsuario() == false)
                RedirectToAction("Index", "Home");

            var produto = await _produtoService.FindByIdWithAssociationAsync(id);
            await _produtoService.DeleteSoftAsync(produto);
            return RedirectToAction(nameof(Index));
        }
    }
}
