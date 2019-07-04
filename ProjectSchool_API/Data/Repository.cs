using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data {
    public class Repository: IRepository {
        private readonly DataContext _context;

        public Repository(DataContext context) {
            _context = context;
        }
        public void Add < T > (T entity) where T: class {
            _context.Add(entity);
        }

        public void Delete < T > (T entity) where T: class {
            _context.Remove(entity);
        }

        public async Task < Aluno[] > GetAllAlunosAsync(bool includeProfessor) {
            IQueryable < Aluno > query = _context.Alunos;

            if (includeProfessor) {
                query = query.Include(aluno => aluno.Professor);
            }

            query = query.AsNoTracking().OrderBy(aluno => aluno.Id);

            return await query.ToArrayAsync();
        }

        public async Task < Professor[] > GetAllProfessoresAsync(bool includeAluno = false) {
            IQueryable < Professor > query = _context.Professores;

            if (includeAluno) {
                query = query.Include(professor => professor.Alunos);
            }

            query = query.AsNoTracking().OrderBy(professor => professor.Id);

            return await query.ToArrayAsync();
        }

        public async Task < Aluno > GetAlunosAsyncById(int AlunoId, bool includeProfessor = false) {
            IQueryable < Aluno > query = _context.Alunos;

            if (includeProfessor) {
                query = query.Include(aluno => aluno.Professor);
            }

            query = query.AsNoTracking()
                .Where(aluno => aluno.Id == AlunoId)
                .OrderBy(aluno => aluno.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task < Aluno[] > GetAlunosAsyncByProfessor(int ProfessorId, bool includeProfessor = false) {

            IQueryable < Aluno > query = _context.Alunos;

            if (includeProfessor) {
                query = query.Include(aluno => aluno.Professor);
            }

            query = query.AsNoTracking()
                .Where(aluno => aluno.ProfessorId == ProfessorId)
                .OrderBy(aluno => aluno.Id);

            return await query.ToArrayAsync();
        }

        public async Task < Professor > GetProfessoresAsyncById(int ProfessorId, bool includeAluno = false) {
            IQueryable < Professor > query = _context.Professores;

            if (includeAluno) {
                query = query.Include(professor => professor.Alunos);
            }

            query = query.AsNoTracking()
                .Where(professor => professor.Id == ProfessorId)
                .OrderBy(professor => professor.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task < bool > SaveChangesAsync() {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Update < T > (T entity) where T: class {
            _context.Update(entity);
        }
    }
}