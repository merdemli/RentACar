using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        readonly List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car {CarId=1,BrandId=1,ColorId=1,ModelYear="2016",DailyPrice= 8000,Description="Mercedes Benz"},
                new Car {CarId=2,BrandId=1,ColorId=2,ModelYear="2018",DailyPrice=10000,Description="Mercedes Jeep"},
                new Car {CarId=3,BrandId=2,ColorId=2,ModelYear="2020",DailyPrice=15000,Description="BMW 1"},
                new Car {CarId=4,BrandId=2,ColorId=3,ModelYear="2015",DailyPrice=16000,Description="BMW 2"},
                new Car {CarId=5,BrandId=3,ColorId=1,ModelYear="2016",DailyPrice=7000,Description="Audi A3"},
                new Car {CarId=6,BrandId=3,ColorId=3,ModelYear="2017",DailyPrice=11000,Description="Audi A4"}
            };
        }

        

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.CarId == car.CarId);
            _car.Remove(carToDelete);
        }
        
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _car.Where(c => c.BrandId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            //burada referans eşitlemiş oluyoruz
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
           
        }
    }
}
