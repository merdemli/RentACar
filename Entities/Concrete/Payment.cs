using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment: BaseEntity
    {
        public int PaymentId { get; set; }
        public int RentalId { get; set; }
        public string CreditCardNumber { get; set; }
        public decimal Price { get; set; }
        public string ExpirationDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

