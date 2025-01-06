using System.Security.Cryptography;
using System.Text;
using EstoqueOnline.Application.DTOS;
using EstoqueOnline.Domain.Models;
using EstoqueOnline.Infra.Data.Repositories;

namespace EstoqueOnline.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;
        public UsuarioService( IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<string> LogarUsuario(UsuarioLoginDTO usuario)
        {
            var usuarioExistenteNoBanco = await _usuarioRepository.FindUsuarioByLogin(usuario.Login);
            if (usuarioExistenteNoBanco is null || !VerifyPasswordHash(usuario.Senha, usuarioExistenteNoBanco))
                return null;
            var token = _tokenService.CreateToken(usuarioExistenteNoBanco);
            return token;
        }

        public async Task RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Nome,usuarioDTO.Senha, usuarioDTO.Login);
            var usuarioCriado = await _usuarioRepository.AddUsuario(usuario);
        }


        private bool VerifyPasswordHash(string password, Usuario usuario)
        {
            using (var hmac = new HMACSHA512(usuario.PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(usuario.PasswordHash);
            }
        }
    }
}
