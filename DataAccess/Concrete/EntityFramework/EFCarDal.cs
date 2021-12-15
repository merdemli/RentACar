using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{                                                                                   //EFCarDal,EFEntityRepositoryBase'den inherit edilir,
    public class EFCarDal : EFEntityRepositoryBase<Car, RentACarContext>, ICarDal //ICarDal'ın istediği tüm operasyonlar EFEntityRepositoryBase içinde var
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors 
                             on c.ColorId equals co.ColorId

                             select new CarDetailDto {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName =co.ColorName,
                                 DailyPrice = c.DailyPrice //dto= entity
                                };

                return result.ToList();  //IQueryable
            }
            //table
            //view - 
        }
    }
}
