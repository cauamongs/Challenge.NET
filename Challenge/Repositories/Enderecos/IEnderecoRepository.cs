using Challenge.Models;
using System.Collections.Generic;

namespace Challenge.Repositories.Enderecos
{
    public interface IEnderecoRepository
    {
        EnderecoModel Adicionar(EnderecoModel endereco);
        List<EnderecoModel> BuscarTodos();
        EnderecoModel ListarPorId(int id);
        EnderecoModel Atualizar(EnderecoModel endereco);
        bool Apagar(int id);
    }
}
