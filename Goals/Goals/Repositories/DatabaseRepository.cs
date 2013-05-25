using System;
using System.Collections.Generic;
using System.Web;
using Goals.Databases;
using Goals.Models;

namespace Goals.Repositories {
    public class DatabaseRepository<T> : IRepository<T> where T : Entity {
        private readonly IDatabase database;

        public DatabaseRepository(IDatabase database) {
            this.database = database;
        }

        public void Create(T @object) {
            database.Get()[CollectionName].Insert(@object);
        }

        public IEnumerable<T> GetAll() {
            return database.Get()[CollectionName].All().ToList<T>();
        }

        public void Update(T @object) {
            database.Get()[CollectionName].Upsert(@object);
        }

        public T Read(Guid id) {
            return (T)database.Get()[CollectionName].FindById(id);
        }

        public void Delete(Guid id) {
            database.Get()[CollectionName].DeleteById(id);
        }

        private static string CollectionName {
            get { return typeof (T).Name + "s"; }
        }
    }
}