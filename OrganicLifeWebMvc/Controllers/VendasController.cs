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
        private readonly ProdutoService _produtoService;

        public VendasController(VendaService vendaService, FornecedorService fornecedorService, ProdutoService produtoService)
        {
            _vendaService = vendaService;
            _fornecedorService = fornecedorService;
            _produtoService = produtoService;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorService.FindAllWithAssociationAsync());
        }

        // GET: Vendas
        public async Task<IActionResult> ProdutosLista(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            return View(await _produtoService.FindAllWithAssociationByFornecedor((int)id));
        }
    }
}
