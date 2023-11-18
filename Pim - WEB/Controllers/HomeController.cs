using Pim___WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Pim___WEB.Data;

namespace Pim___WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly db_folha_pagamento_pim_context _context;
        public static string LogadoCPF { get; set; }
        public static string LogadoNome { get; set; }
        public static string LogadoCargo { get; set; }

        public HomeController(ILogger<HomeController> logger, db_folha_pagamento_pim_context context)
        {
            _logger = logger;
            _context = context;
        }

        // método para zerar as variáveis estáticas
        public void ResetarVariaveis()
        {
            LogadoCPF = null;
            LogadoNome = null;
            LogadoCargo = null;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ResetarVariaveis();
            Funcionarios funcionarioLogin = new Funcionarios();
            return View(funcionarioLogin);
        }

        /* verificar se existe um cpf e senha iguais no banco de dados ao que foi digitado na tela, 
        também vai salvar o nome e o cargo do funcionário para mostrar na tela de menu se o login for bem sucedido */
        [HttpPost]
        public IActionResult Index(Funcionarios funcionarioLogin)
        {
            var loginUsuario = _context.Funcionarios.Where(funcionario => funcionario.CPF == funcionarioLogin.CPF && funcionario.Senha == funcionarioLogin.Senha).FirstOrDefault();

            if (loginUsuario == null)
            {
                ViewBag.loginUsuario = 0;
            }

            else
            {
                LogadoCPF = funcionarioLogin.CPF;
                LogadoNome = loginUsuario.NomeCompleto;

                var cargoFuncionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.CPF == LogadoCPF);

                if (cargoFuncionario != null)
                {
                    LogadoCargo = cargoFuncionario.Cargo;
                }

                return RedirectToAction("Menu", "Home");
            }

            return View(funcionarioLogin);
        }

        // exibir o nome e o cargo do funcionário
        public IActionResult Menu()
        {
            ViewBag.CpfFuncionarioLogado = LogadoCPF;
            ViewBag.nomeFuncionarioLogado = LogadoNome;
            ViewBag.cargoFuncionarioLogado = LogadoCargo;
            return View();
        }

        // se clicar no botão de sair da conta, zera as variáveis estáticas e retorna a tela inicial
        public IActionResult VoltarInicio()
        {
            ResetarVariaveis();
            return RedirectToAction("Index", "Home");
        }

        // exibir as folhas de pagamento de acordo com o funcionário que fez o login
        public IActionResult VisualizarRelatorio()
        {
            var relatorioPagamentoFuncionario = _context.RelatorioPagamento.Where(funcionarios => funcionarios.CPF == LogadoCPF).ToList();

            return View(relatorioPagamentoFuncionario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}