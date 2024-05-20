using Microsoft.AspNetCore.Mvc;
using Challenge.Models;
using Challenge.Repositories.Usuarios;
using Challenge.Data;

namespace Challenge.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        
        public IActionResult Index()
        {
            List<UsuarioModel> user = _usuarioRepository.BuscarTodos();
            return View(user);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           UsuarioModel user =  _usuarioRepository.ListarPorId(id);
            return View(user);
        }

        public IActionResult Apagar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }

       public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.Apagar(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel user)
        {
            _usuarioRepository.Adicionar(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel user)
        {
            _usuarioRepository.Atualizar(user);
            return RedirectToAction("Index");
        }
    } 
}
