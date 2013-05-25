using System.Web.SessionState;

namespace Goals.SessionState {
    public class Session : ISession {
        private readonly HttpSessionState session;

        public Session(HttpSessionState session) {
            this.session = session;
        }

        public void Add(string key, object value) {
            session.Add(key, value);
        }
    }
}