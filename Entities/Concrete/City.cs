using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class City : BaseEntity
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

    }
}
