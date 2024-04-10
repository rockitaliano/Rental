using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
