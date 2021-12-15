using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Abstract
{
    public abstract class BaseEntity : IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
