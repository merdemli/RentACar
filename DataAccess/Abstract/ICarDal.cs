using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>     //sistemi  Car için yapılandırdık
    {
        //ürüne ait özel operasyonlar yazılacak, örn ürün detayı GetDetails

        List<CarDetailDto> GetCarDetails();
    }

    
}
