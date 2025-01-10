

using backend.models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DDFinanceContext : DbContext
    {
        public DDFinanceContext(DbContextOptions options) : base(options)
        {
        }
        public required DbSet<Insurance> Insurances { get; set; }
    }
}