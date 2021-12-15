using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public  class CarImage: BaseEntity
    {
        public int CarImageID { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}

// admin, moderator, user

// article.add, article.update, article.delete