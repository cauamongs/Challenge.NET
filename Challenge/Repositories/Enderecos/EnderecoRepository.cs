using Challenge.Data;
using Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Repositories.Enderecos
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly FIAPDbContext _bdContext;

        public EnderecoRepository(FIAPDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        public List<EnderecoModel> BuscarTodos()
        {
            return _bdContext.Endereco.Include(p => p.Usuario).ToList();
        }

        public EnderecoModel Adicionar(EnderecoModel endereco)
        {

            endereco.Usuario = _bdContext.Usuarios.Find(endereco.UsuarioId);

            _bdContext.Endereco.Add(endereco);
            _bdContext.SaveChanges();
            return endereco;
        }

        public EnderecoModel ListarPorId(int id)
        { 
            return _bdContext.Endereco.Include(p => p.Usuario).FirstOrDefault(endereco => endereco.Id == id);
        }

        public EnderecoModel Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoDb = ListarPorId(endereco.Id);

            if (enderecoDb == null) throw new System.Exception("Houve um erro na atualização do endereço");

            enderecoDb.Cep = endereco.Cep;
            enderecoDb.Logradouro = endereco.Logradouro;
            enderecoDb.Numero = endereco.Numero;
            enderecoDb.Complemento = endereco.Complemento;
            enderecoDb.UsuarioId = endereco.UsuarioId;

            _bdContext.Endereco.Update(enderecoDb);
            _bdContext.SaveChanges();

            return enderecoDb;
        
        }

        public bool Apagar(int id)
        {
            EnderecoModel enderecoDb = ListarPorId(id);

            if (enderecoDb == null) throw new System.Exception("Houve um erro ao deletar endereço");

            _bdContext.Endereco.Remove(enderecoDb);
            _bdContext.SaveChanges();

            return true;
        }
    }
}