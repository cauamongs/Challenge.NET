using Challenge.Models;

namespace Challenge.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        UsuarioModel Adicionar(UsuarioModel user);
        List<UsuarioModel> BuscarTodos();

        UsuarioModel ListarPorId(int id);
        UsuarioModel Atualizar(UsuarioModel user);
        bool Apagar(int id);


    }
}
