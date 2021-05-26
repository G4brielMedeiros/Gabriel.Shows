using System.Collections.Generic;

namespace Project.Shows.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        void Insert(T entity);
        
        T ReadById(int id);

        void UpdateById(int id, T entity);

        void DeleteById(int id);
        
        int NextId();

    }
}