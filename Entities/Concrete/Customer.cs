
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer: User
    {
        //[Key]
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public int FindeksScore { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
