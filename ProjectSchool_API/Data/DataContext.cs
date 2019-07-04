using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>().HasData(
                new List<Professor>(){
                    new Professor(){
                        Id = 1,
                        Nome = "Vinicius",
                        Sobrenome = "Andrade"
                    },
                    new Professor(){
                        Id = 2,
                        Nome = "Lourdes",
                        Sobrenome = "Almeida"
                    },
                    new Professor(){
                        Id = 3,
                        Nome = "Teraza",
                        Sobrenome= "Santos"
                    }
                }
            );

            builder.Entity<Aluno>().HasData(
                new List<Aluno>(){
                    new Aluno(){
                        Id = 1,
                        Nome = "Thiago",
                        Sobrenome = "Brito",
                        DataNasc = "03/05/1987",
                        ProfessorId = 1
                    },
                    new Aluno(){
                        Id = 2,
                        Nome = "Maria",
                        Sobrenome = "Laura",
                        DataNasc = "03/07/2014",
                        ProfessorId = 2
                    },
                    new Aluno(){
                        Id = 3,
                        Nome = "Kléber",
                        Sobrenome= "Felipe",
                        DataNasc = "27/04/2012",
                        ProfessorId = 1
                    }
                }
            );
        }
    }
}