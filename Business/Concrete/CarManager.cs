using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal) //constructor injection
        {
            _carDal = carDal; //alttan erişebilmek için referansını aldık
        }

        public IResult Add(Car car)
        {
            //if (car.CarName.Length >= 2)
            //{
            //    if (car.DailyPrice > 0)
            //    {

            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            //    }
            //    else
            //    {
            //        return new ErrorResult("Daily PRice must be greater than zero");
            //    }
            //}
            //else
            //{
            //    return new SuccessResult( Messages.CarNameInvalid);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Car deleted");

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(car.ModelYear + " yılındaki araç güncellendi");

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "All Car");
        }



        public IDataResult<List<CarDetailDto>> GetAllCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), " Car details listed");
        }



        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.DailyPrice >= min && x.DailyPrice <= max));
        }



        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId), " ...");
        }


        //public List<Car> GetCarsByBrandId(int brandId)                                    //BrandId'ye göre getir 
        //{
        //    return _carDal.GetAll(p => p.BrandId == brandId);


        //                        //her p için

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), "...........");
        }

        //public List<Car> GetCarsByColorId(int colorId) //expression, filter,IentityRepository'de verilir
        //{
        //    return _carDal.GetAll(p => p.ColorId == colorId);
        //}

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
    }
}
