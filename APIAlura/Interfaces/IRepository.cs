using APIAlura.Entity;

namespace APIAlura.Interfaces
{
    public interface IRepository<T> where T : Entidade
    {

        IList<T> ObterTodos();

        T ObterPorId(int id);

        void Cadastrar(T entidade);

        void Editar(T entidade);

        void Deletar(int id);
    }
}
