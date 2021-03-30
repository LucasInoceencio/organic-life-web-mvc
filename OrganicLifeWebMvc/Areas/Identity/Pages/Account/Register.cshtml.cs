using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OrganicLifeWebMvc.Models;
using OrganicLifeWebMvc.Services;

namespace OrganicLifeWebMvc.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ClienteService _clienteService;
        private readonly FornecedorService _fornecedorService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ClienteService clienteService,
            FornecedorService fornecedorService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _clienteService = clienteService;
            _fornecedorService = fornecedorService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Tipo Usuário")]
            public string TipoUsuario { get; set; }

            [Required]
            public string NomeCompleto { get; set; }
            public string NomeFantasia { get; set; }
            public string RazaoSocial { get; set; }
            public string Cnpj { get; set; }
            [Required]
            public string Cpf { get; set; }
            public string Rg { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime DataNascimento { get; set; }
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Numero { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Cep { get; set; }
            public string Telefone { get; set; }
            [Required]
            public string Celular { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var endereco = new Endereco()
                {
                    Logradouro = Input.Logradouro,
                    Bairro = Input.Bairro,
                    Numero = Input.Numero,
                    Cidade = Input.Cidade,
                    Estado = Input.Estado,
                    Cep = Input.Cep
                };

                var pessoaFisica = new Pessoa()
                {
                    Nome = Input.NomeCompleto,
                    Cpf = Input.Cpf,
                    Rg = Input.Rg,
                    DataNascimento = Input.DataNascimento,
                    Endereco = endereco,
                    Email = Input.Email,
                    Telefone = Input.Telefone,
                    Celular = Input.Celular
                };

                // Criar cliente ou fornecedor e persistir no banco
                if (!string.IsNullOrWhiteSpace(Input.TipoUsuario) && Input.TipoUsuario.ToLower().Equals("fornecedor"))
                {
                    var pessoaJuridica = new PessoaJuridica()
                    {
                        RazaoSocial = Input.RazaoSocial,
                        NomeFantasia = Input.NomeFantasia,
                        Cnpj = Input.Cnpj,
                        Endereco = endereco,
                        Email = Input.Email,
                        Telefone = Input.Telefone,
                        Celular = Input.Celular,
                        Responsavel = pessoaFisica
                    };

                    var fornecedor = new Fornecedor()
                    {
                        PessoaJuridica = pessoaJuridica
                    };

                    await _fornecedorService.InsertAsync(fornecedor, new ApplicationUser() { Id = "system@organiclife.com.br"});
                }
                if (!string.IsNullOrWhiteSpace(Input.TipoUsuario) && Input.TipoUsuario.ToLower().Equals("cliente"))
                {
                    var cliente = new Cliente()
                    {
                        Pessoa = pessoaFisica
                    };

                    await _clienteService.InsertAsync(cliente, new ApplicationUser() { Id = "system@organiclife.com.br" });
                }

                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, TipoUsuario = Input.TipoUsuario, Pessoa = pessoaFisica };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
