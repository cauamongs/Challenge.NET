using Challenge.Data;
using Challenge.Models;

namespace Challenge.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FIAPDbContext _bdContext;
        public UsuarioRepository(FIAPDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
           return _bdContext.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel user)
        {
           
           _bdContext.Usuarios.Add(user);
           _bdContext.SaveChanges();
           return user;
        }

        public UsuarioModel Alterar(UsuarioModel user)
        {

            _bdContext.Usuarios.Add(user);
            _bdContext.SaveChanges();
            return user;
        }

        public UsuarioModel ListarPorId(int id)
        {
           
           return _bdContext.Usuarios.FirstOrDefault(user => user.Id == id);
            
        }

        public UsuarioModel Atualizar(UsuarioModel user)
        {
            UsuarioModel userDb = ListarPorId((int)user.Id);

            if (userDb == null) throw new System.Exception("Houve um erro na atualização do usuário ");

            userDb.Username = user.Username;
            userDb.Email = user.Email;
            userDb.CPF = user.CPF;

           

            _bdContext.Usuarios.Update(userDb);
            _bdContext.SaveChanges();

            return userDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel userDb = ListarPorId(id);

            if (userDb == null) throw new System.Exception("Houve um erro ao deletar o usuário ");

            _bdContext.Usuarios.Remove(userDb);
            _bdContext.SaveChanges();

            return true;
            
        }
    }
}
