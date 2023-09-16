using APIAlura.Entity;
using APIAlura.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIAlura.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entidade
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Cadastrar(T entidade)
        {
         _dbSet.Add(entidade);
        _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            if(ObterPorId(id) != null)
            {
                _dbSet.Remove(ObterPorId(id));
                _context.SaveChanges();
            }
            
        }

        public void Editar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }
    }
}
