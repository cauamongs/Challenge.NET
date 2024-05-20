using Challenge.Models;
using System.Collections.Generic;

namespace Challenge.Repositories.PreferenciaViagem
{
    public interface IPreferenciaViagemRepository
    {
        PreferenciaViagemModel Adicionar(PreferenciaViagemModel preferencia);
        List<PreferenciaViagemModel> BuscarTodos();
        PreferenciaViagemModel ListarPorId(int id);
        PreferenciaViagemModel Atualizar(PreferenciaViagemModel preferencia);
        bool Apagar(int id);
    }
}