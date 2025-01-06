using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Validation;

namespace EstoqueOnline.Domain.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Usuario()
        {
            
        }
        public Usuario(string name, string password, string login)
        {
            Id = Guid.NewGuid().ToString();
            Nome = name;
            Login = login;
            CreatedDate = DateTime.Now;
            ValidateDomain(name, password, login);
            CreatePasswordHash(password);

        }
        private void CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public void ValidateDomain(string name, string password, string login)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome Inválido para usuário");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Senha Inválida para usuário");
            DomainValidationException.When(string.IsNullOrEmpty(login), "Login Inválido para usuário");
            DomainValidationException.When(name.Length < 5, "Nome Inválido para usuário tamanho minímo de 5 characters");
            DomainValidationException.When(password.Length < 5, "Senha inválida para usuário tamanho minímo de 5 characters");
            DomainValidationException.When(login.Length < 5, "Login inválido para usuário tamanho minímo de 5 characters");
        }
    }
}
