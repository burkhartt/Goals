using System.ComponentModel.DataAnnotations;
using Goals.Controllers;

namespace Goals.Models {
    public class Goal : Entity {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}