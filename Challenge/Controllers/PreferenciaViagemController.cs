using Microsoft.AspNetCore.Mvc;
using Challenge.Models;
using Challenge.Repositories.PreferenciaViagem;
using Challenge.ViewModels;
using Challenge.Repositories.Usuarios;

namespace Challenge.Controllers
{
    public class PreferenciaViagemController : Controller
    {
        private readonly IPreferenciaViagemRepository _preferenciaViagemRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public PreferenciaViagemController(IPreferenciaViagemRepository preferenciaViagemRepository, IUsuarioRepository usuarioRepository)
        {
            _preferenciaViagemRepository = preferenciaViagemRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<PreferenciaViagemModel> preferencia = _preferenciaViagemRepository.BuscarTodos();
            return View(preferencia);
        }

        public IActionResult Criar() 
        {
            var viewModel = new PreferenciaViagemViewModel
            {
                PreferenciaViagem = new PreferenciaViagemModel(),
                Usuarios = _usuarioRepository.BuscarTodos()
            };
            return View(viewModel);
        }

        public IActionResult Apagar(int id)
        {
            PreferenciaViagemModel preferencia = _preferenciaViagemRepository.ListarPorId(id);
            return View(preferencia);
        }


        [HttpPost]
        public IActionResult Criar(PreferenciaViagemViewModel viewModel)
        {
  
            
            _preferenciaViagemRepository.Adicionar(viewModel.PreferenciaViagem);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var preferencia = _preferenciaViagemRepository.ListarPorId(id);
            var viewModel = new PreferenciaViagemViewModel
            {
                PreferenciaViagem = preferencia,
                Usuarios = _usuarioRepository.BuscarTodos()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Atualizar(PreferenciaViagemViewModel viewModel)
        {
           
            var preferencia = _preferenciaViagemRepository.ListarPorId(viewModel.PreferenciaViagem.Id);

           

            // Atualizar as propriedades da preferência de viagem com os valores do formulário
            preferencia.TipoCulinaria = viewModel.PreferenciaViagem.TipoCulinaria;
            preferencia.RestricoesAlimentares = viewModel.PreferenciaViagem.RestricoesAlimentares;
            preferencia.TipoTransporte = viewModel.PreferenciaViagem.TipoTransporte;
            preferencia.TipoHospedagem = viewModel.PreferenciaViagem.TipoHospedagem;
            preferencia.ViajaSozinho = viewModel.PreferenciaViagem.ViajaSozinho;
            preferencia.UsuarioId = viewModel.PreferenciaViagem.UsuarioId;

            _preferenciaViagemRepository.Atualizar(preferencia);
            return RedirectToAction("Index");
        }



        public IActionResult DeletarPreferencia(int id)
        {
            _preferenciaViagemRepository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}