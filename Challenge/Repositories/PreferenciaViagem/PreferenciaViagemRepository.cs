using Challenge.Data;
using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Challenge.Repositories.PreferenciaViagem
{
    public class PreferenciaViagemRepository : IPreferenciaViagemRepository
    {
        private readonly FIAPDbContext _bdContext;

        public PreferenciaViagemRepository(FIAPDbContext bdContext)
        {
            _bdContext = bdContext;
        }

        public List<PreferenciaViagemModel> BuscarTodos()
        {
            return _bdContext.PreferenciaViagem.Include(p => p.Usuario).ToList();
        }

        public PreferenciaViagemModel Adicionar(PreferenciaViagemModel preferencia)
        {
            
            preferencia.Usuario = _bdContext.Usuarios.Find(preferencia.UsuarioId);

            _bdContext.PreferenciaViagem.Add(preferencia);
            _bdContext.SaveChanges();
            return preferencia;
        }

        public PreferenciaViagemModel ListarPorId(int id)
        {
            return _bdContext.PreferenciaViagem.Include(p => p.Usuario).FirstOrDefault(preferencia => preferencia.Id == id);
        }

        public PreferenciaViagemModel Atualizar(PreferenciaViagemModel preferencia)
        {
            PreferenciaViagemModel preferenciaDb = ListarPorId(preferencia.Id);

            if (preferenciaDb == null) throw new System.Exception("Houve um erro na atualização da preferência de viagem");

            preferenciaDb.TipoCulinaria = preferencia.TipoCulinaria;
            preferenciaDb.RestricoesAlimentares = preferencia.RestricoesAlimentares;
            preferenciaDb.TipoTransporte = preferencia.TipoTransporte;
            preferenciaDb.TipoHospedagem = preferencia.TipoHospedagem;
            preferenciaDb.ViajaSozinho = preferencia.ViajaSozinho;
            preferenciaDb.UsuarioId = preferencia.UsuarioId;

            _bdContext.PreferenciaViagem.Update(preferenciaDb);
            _bdContext.SaveChanges();

            return preferenciaDb;
        }

        public bool Apagar(int id)
        {
            PreferenciaViagemModel preferenciaDb = ListarPorId(id);

            if (preferenciaDb == null) throw new System.Exception("Houve um erro ao deletar a preferência de viagem");

            _bdContext.PreferenciaViagem.Remove(preferenciaDb);
            _bdContext.SaveChanges();

            return true;
        }
    }
}