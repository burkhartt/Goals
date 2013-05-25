using System;
using System.Collections.Generic;
using Goals.Models;

namespace Goals.Repositories {
    public interface IRepository<T> where T : Entity {
        void Create(T @object);
        IEnumerable<T> GetAll();
        void Update(T @object);
        T Read(Guid id);
        void Delete(Guid id);
    }
}