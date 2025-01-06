using EstoqueOnline.Domain.Models;
using EstoqueOnline.Domain.Validation;
using FluentAssertions;

namespace EstoqueOnline.Domain.Tests.UsuarioTestsFolder
{
    public class UsuarioTests
    {

        [Theory]
        [InlineData("", "", "")]
        [InlineData("abc", "abc", "abc")]
        [InlineData("abcd", "abcd", "abcd")]
        public void QuandoCriarUsuarioIncorretoDeveRetornarException(string name,string password,string login)
        {
            //Arrange
            Action user = () => new Usuario(name,password,login);
            user.Should().Throw<DomainValidationException>();
        }

        [Theory]
        [InlineData("abc123", "abc123", "abc123")]
        [InlineData("abcdwqe", "abcdwqe", "abcdwqe")]
        public void QuandoCriarUsuarioNaoDeveRetornarException(string name, string password, string login)
        {
            //Arrange
            Action user = () => new Usuario(name, password, login);
            user.Should().NotThrow<DomainValidationException>();
        }
    }
}
