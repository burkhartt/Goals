using System;
using System.Collections.Generic;
using System.Web;
using Goals.Models;
using Goals.SessionState;

namespace Goals.Repositories {
    public class SessionRepository<T> : IRepository<T> where T : Entity {
        private readonly ISession session;

        public SessionRepository(ISession session) {
            this.session = session;
        }

        public void Create(T @object) {
            
        }

        public IEnumerable<T> GetAll() {
            return new T[] {};
        }

        public void Update(T @object) {
            
        }

        public T Get(Guid id) {
            return default(T);
        }

        public void Delete(Guid id) {
            
        }
    }
}