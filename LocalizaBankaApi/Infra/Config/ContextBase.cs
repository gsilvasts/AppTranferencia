using LocalizaBankApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizaBankaApi.Infra.Config
{
    public class ContextBase: DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }        
    }
}
