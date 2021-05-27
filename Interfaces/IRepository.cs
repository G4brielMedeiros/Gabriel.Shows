using System.Collections.Generic;

namespace Gabriel.Shows
{
    public interface IRepository<T> where T : Entity
    {
        List<T> List();

        void Insert(T entity);
        
        T ReadById(int id);

        void UpdateById(int id, T entity);

        void DeleteById(int id);
        
        int NextId();

    }
}