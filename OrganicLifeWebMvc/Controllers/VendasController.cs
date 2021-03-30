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
        private readonly UserService _userService;

        public VendasController(
            VendaService vendaService, 
            FornecedorService fornecedorService, 
            ProdutoService produtoService, 
            UserService userService)
        {
            _vendaService = vendaService;
            _fornecedorService = fornecedorService;
            _produtoService = produtoService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _fornecedorService.FindAllWithAssociationAsync());
        }

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
