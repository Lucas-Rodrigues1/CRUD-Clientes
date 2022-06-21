using ControledeContatos.Data;
using ControledeContatos.Models;

namespace ControledeContatos.Repositorio
{
    public class ContatoRepositorio: IContatoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContex)
        {
            _bancoContext = bancoContex;
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
    }
}
