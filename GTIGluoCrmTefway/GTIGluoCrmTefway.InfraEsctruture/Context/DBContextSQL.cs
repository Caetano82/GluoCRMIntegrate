using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GTIGluoCrmTefway.InfraEsctruture.Context
{
    public class DBContextSQL : DbContext
    {
        public DBContextSQL(DbContextOptions<DBContextSQL> options) : base(options)
        {
        }

        // Adicione DbSets aqui se necessário

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
    }

}