using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoqueOnline.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EstoqueOnline.Infra.Data.Identity
{
    public class UsuarioContext:DbContext
    {
        public UsuarioContext()
        {
            
        }

        public UsuarioContext(DbContextOptions<UsuarioContext> opt) : base(opt)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                throw new Exception("Banco não configurado");
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
