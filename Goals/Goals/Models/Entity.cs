﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Goals.Models {
    public abstract class Entity {
        protected Entity() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}