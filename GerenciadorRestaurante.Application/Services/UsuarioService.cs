using AutoMapper;
using GerenciadorRestaurante.Application.Models.InputModels;
using GerenciadorRestaurante.Application.Models.ViewModels;
using GerenciadorRestaurante.Application.Services.Interfaces;
using GerenciadorRestaurante.Core.Entites;
using GerenciadorRestaurante.Core.Exceptions;
using GerenciadorRestaurante.Core.Repositories;
using SecureIdentity.Password;

namespace GerenciadorRestaurante.Application.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioViewModel> CreateAsync(UsuarioInputModel request)
        {
            var usuario = _mapper.Map<Usuario>(request);

            usuario.SenhaCriptografa = PasswordHasher.Hash(request.Senha);

            var model = await _usuarioRepository.InserirAsync(usuario);

            return _mapper.Map<UsuarioViewModel>(model);
        }

        public async Task<UsuarioViewModel> GetByIdAsync(long id)
        {
            var model = await _usuarioRepository.ObterPorIdAsync(id) ?? throw new NotFoundException();

            return _mapper.Map<UsuarioViewModel>(model);
        }

        public async Task<UsuarioViewModel> GetUsuarioByEmail(string email)
        {
            var model = await _usuarioRepository.GetByEmailAsync(email) ?? throw new NotFoundException();

            return _mapper.Map<UsuarioViewModel>(model);
        }
    }
}
