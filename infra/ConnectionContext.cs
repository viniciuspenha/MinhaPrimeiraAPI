using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI.model;

namespace MinhaPrimeiraAPI.infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Produto> Produto {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
              "Server=localhost;" +
              "Port=49153;" + // substitua pela porta que esta rodando seu mysql
              "Database=telos;" +
              "User Id=root;" + // substitua pelo usuario que esta usando no seu mysql
              "Password=mysqlpw;", // substitua pela senha que esta usando no seu mysql
              new MySqlServerVersion(new Version(8, 0, 3)));
        }
    }
}
