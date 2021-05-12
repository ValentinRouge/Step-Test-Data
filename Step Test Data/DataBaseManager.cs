using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{

    class DBManager
    {
        public List<TestsHistory> Search(string searched)
        {
            using (var context = new TestContext())
            {
                return context.TestsHistory.Where(test => test.Name.Contains(searched)).ToList();
            }
        }

        public void Add(string Name, int Score, int? Age = null)
        {

            var newTest = new TestsHistory
            {
                Name = Name,
                Score = Score,
                Age = Age,
            };

            using (var context = new TestContext())
            {
                context.TestsHistory.Add(newTest);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new TestContext())
            {
                context.TestsHistory.Remove(new TestsHistory { Id = id });
                context.SaveChanges();
            }
        }
    }
    class TestContext : DbContext
    {

        public DbSet<TestsHistory> TestsHistory { get; set; }

    }

    class TestsHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //autoincrement
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Score { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //actual date
        public DateTime Date { get; set; }
        
        public int? Age { get; set;  }
    }
}
