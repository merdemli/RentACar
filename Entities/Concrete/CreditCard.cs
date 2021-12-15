using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : BaseEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string CardNo { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvc { get; set; }
    }
}
