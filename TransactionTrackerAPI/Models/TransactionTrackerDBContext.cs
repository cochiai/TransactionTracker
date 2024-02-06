using Microsoft.EntityFrameworkCore;

namespace TransactionTrackerService.Models
{
    public partial class TransactionTrackerDBContext : DbContext
    {
        public TransactionTrackerDBContext()
        {
        }

        public TransactionTrackerDBContext(DbContextOptions<TransactionTrackerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();

                entity.HasData(
                    new Category() { Id = 1, Name = "Utility" },
                    new Category() { Id = 2, Name = "Rent" },
                    new Category() { Id = 3, Name = "Food" },
                    new Category() { Id = 4, Name = "Tax" },
                    new Category() { Id = 5, Name = "Transport" },
                    new Category() { Id = 6, Name = "Shopping" },
                    new Category() { Id = 7, Name = "Leisure" },
                    new Category() { Id = 8, Name = "Health" },
                    new Category() { Id = 9, Name = "Other" },
                    new Category() { Id = 10, Name = "Insurance" }
                );
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Abbreviation}).IsUnique();


                entity.HasData(
                    new Currency() { Id = 1, Name = "Swiss Franc", Abbreviation = "CHF" }
                );
            });

            modelBuilder.Entity<Person>().HasData(
                new Person() { Id = 1, Firstname = "Max", Lastname = "Muster" },
                new Person() { Id = 2, Firstname = "Hans", Lastname = "Meier" },
                new Person() { Id = 3, Company = "Company Ltd." }
            );

            modelBuilder.Entity<Transaction>(entity =>
            {

                entity.HasOne(d => d.Category).WithMany(p => p.Transactions).HasForeignKey(e => e.CategoryId);
                entity.HasOne(d => d.Sender).WithMany(p => p.SenderTransactions).HasForeignKey(e => e.SenderId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Recipient).WithMany(p => p.RecipientTransactions).HasForeignKey(e => e.RecipientId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(d => d.Currency).WithMany(p => p.Transactions).HasForeignKey(e => e.CurrencyId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
