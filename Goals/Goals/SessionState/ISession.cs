using System.Web;
using Goals.Models;

namespace Goals.SessionState {
    public interface ISession  {
        void Add(string key, object value);
    }
}