using Goals.Metadata;

namespace Goals.Models {
    public class Goal : Entity {
        public string Title { get; set; }
        [TextArea]
        public string Description { get; set; }
    }
}