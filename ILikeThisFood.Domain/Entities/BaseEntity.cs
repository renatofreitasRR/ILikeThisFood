using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILikeThisFood.Domain.Entities
{
    public abstract class BaseEntity
    {
        public string Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        protected void SetCreatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
