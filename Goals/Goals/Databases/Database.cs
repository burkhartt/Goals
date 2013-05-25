using System.Web.Configuration;
using Simple.Data.MongoDB;

namespace Goals.Databases {
    public class Database : IDatabase {
        public dynamic Get() {
            return Simple.Data.Database.Opener.OpenMongo(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}