using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Step_Test_Data
{
    class DBManager
    {
        public List<TestsHistory> Search(string searched)
        {
            using (var context = new DatabaseContext())
            {
                return context.TestsHistory.Where(test => test.Name.Contains(searched)).ToList();
            }
        }

        public TestsHistory getByID(int number)
        {
            using (var context = new DatabaseContext())
            {
                return context.TestsHistory.Where(test => test.Id.Equals(number)).Single();
            }
        }

        public List<TestsHistory> getAll()
        {
            using (var context = new DatabaseContext())
            {
                return context.TestsHistory.ToList();
            }
        }

        public void Add(string Name, int Score, int? Age = null)
        {

            var newTest = new TestsHistory
            {
                Name = Name,
                Score = Score,
                Age = Age,
                Date = DateTime.Now
            };

            using (var context = new DatabaseContext())
            {
                context.TestsHistory.Add(newTest);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new DatabaseContext())
            {
                Console.WriteLine(id);
                Console.WriteLine(context.TestsHistory.Count());
                var test = context.TestsHistory.Single(o => o.Id == id);
                context.TestsHistory.Remove(test);
                context.SaveChanges();
                Console.WriteLine(context.TestsHistory.Count());
            }
        }
    }

    public class DatabaseContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Database » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « Step_Test_Data.Database » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Database » dans le fichier de configuration de l'application.
        public DatabaseContext()
            : base("name=Database")
        {
            Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
            Configuration.ValidateOnSaveEnabled = false;
        }
        public DbSet<TestsHistory> TestsHistory { get; set; }


        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class TestsHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Score { get; set; }

        public DateTime Date { get; set; }

        public int? Age { get; set; }
    }
}