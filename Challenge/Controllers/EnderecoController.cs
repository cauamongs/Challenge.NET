using Microsoft.AspNetCore.Mvc;
using Challenge.Models;
using Challenge.Repositories.Enderecos;
using Challenge.ViewModels;
using Challenge.Repositories.Usuarios;

namespace Challenge.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository, IUsuarioRepository usuarioRepository)
        {
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<EnderecoModel> endereco = _enderecoRepository.BuscarTodos();
            return View(endereco);
        }

        public IActionResult Criar() 
        {
            var viewModel = new EnderecoViewModel
            {
                Endereco = new EnderecoModel(),
                Usuarios = _usuarioRepository.BuscarTodos()
            };
            return View(viewModel);
        }

        public IActionResult Apagar(int id)
        {
            EnderecoModel endereco = _enderecoRepository.ListarPorId(id);
            return View(endereco);
        }


        [HttpPost]
        public IActionResult Criar(EnderecoViewModel viewModel)
        {
  
            
            _enderecoRepository.Adicionar(viewModel.Endereco);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var endereco = _enderecoRepository.ListarPorId(id);
            var viewModel = new EnderecoViewModel
            {
                Endereco = endereco,
                Usuarios = _usuarioRepository.BuscarTodos()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Atualizar(EnderecoViewModel viewModel)
        {
           
            var endereco = _enderecoRepository.ListarPorId(viewModel.Endereco.Id);

           

            endereco.Cep = viewModel.Endereco.Cep;
            endereco.Logradouro = viewModel.Endereco.Logradouro;
            endereco.Numero = viewModel.Endereco.Numero;
            endereco.Complemento = viewModel.Endereco.Complemento;
            endereco.UsuarioId = viewModel.Endereco.UsuarioId;

            _enderecoRepository.Atualizar(endereco);
            return RedirectToAction("Index");
        }



        public IActionResult DeletarEndereco(int id)
        {
            _enderecoRepository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}