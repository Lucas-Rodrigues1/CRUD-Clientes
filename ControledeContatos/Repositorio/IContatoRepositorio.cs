using ControledeContatos.Models;
using System.Collections.Generic;

namespace ControledeContatos.Repositorio
{
    public interface IContatoRepositorio
    {

        ContatoModel ListarPorId(int id);
        
        public List<ContatoModel> BuscarTodos();


        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool remove(int id);

    }
}
