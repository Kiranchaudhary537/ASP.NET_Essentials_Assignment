using Microsoft.EntityFrameworkCore;

namespace LearnAspNet.Modal
{
    public class KeyPairContext : DbContext
    {
        public KeyPairContext(DbContextOptions<KeyPairContext> options)
            : base(options)
        {
        }

        public DbSet<KeyPair> KeyPairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KeyPair>().HasKey(kp => kp.Key);
        }
    }
}
