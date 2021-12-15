using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerRegisterDto
    {
        //public CustomerRegisterDto()
        //{
        //    Customer customer = new Customer();
        //    var model = new CustomerRegisterDto();

        //    customer.CreatedAt = System.DateTime.Now;
        //    customer.Email = model.Email;
        //    customer.FirstName = model.FirstName;
        //}
      
        public int FindeksScore { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
