using Goals.Models;
using Goals.Repositories;

namespace Goals.Controllers {
    public class GoalsController : CrudController<Goal> {
        public GoalsController(IRepository<Goal> repository) : base(repository) {}        
    }
}