using Microsoft.EntityFrameworkCore;

namespace TesteClasses.Models
{
    public class TesteClassesContext : DbContext {

        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        public DbSet<ProdutoModel> ProdutoModel { get; set; }

        public DbSet<CondicaoPagamentoModel> CondicaoPagamentoModel { get; set; }

        public DbSet<ClienteModel> ClienteModel { get; set; }

        public DbSet<PropostaModel> PropostaModel { get; set; }

        public DbSet<PropostaItemModel> PropostaItemModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(@"Server=crm-teste.database.windows.net;User ID=adminserver;Password=crm@1234#;Database=crm_api;Integrated Security=False");
        }
    }
}