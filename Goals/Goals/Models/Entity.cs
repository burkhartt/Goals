using System;

namespace Goals.Models {
    public abstract class Entity {
        protected Entity() {
            if (Id == Guid.Empty) {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; private set; }
    }
}