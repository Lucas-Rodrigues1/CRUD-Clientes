using ControledeContatos.Models;
using ControledeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControledeContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index()
        {
           List<ContatoModel> contatos =_contatoRepositorio.BuscarTodos();
            return View(contatos);


        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {

            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);


        }
        
        public IActionResult remove(int id)
        {
           
            

            bool apagado = _contatoRepositorio.remove(id);

            try
            {
                if (apagado)
                {
                  
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                   

                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao apagar o contato!";
                }
                return RedirectToAction("Index");

            }
            catch(SystemException erro)
            {
                TempData["MensagemErro"] = "Erro ao apagar o contato!";
                return RedirectToAction("Index");
            }
        }
      

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");

                }

                return View(contato);
            }

            catch(System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Erro ao cadastrar o contato, tente novamente!:{erro.Message}";
                return RedirectToAction("Index");
            }
        
        }
       
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");

                }

                return View("Editar", contato);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao e o contato, tente novamente!:{erro.Message}";
                return RedirectToAction("Index");
            }

                     
          
        }
    }
}
