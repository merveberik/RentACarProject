using Business.Absrtact;
using DataAccess.Absrtact;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarsService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Daily price must be more than 0");
            }
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                Console.WriteLine("This car was deleted");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("There is not this car");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }
        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {

            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            return _carDal.GetProductDetail();
        }


        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Car was updated");
            }
            else
            {
                Console.WriteLine("Please, write more than 0 price");
            }
        }

        public List<Car> GetModelYear(int year)
        {
            return _carDal.GetAll(c => c.ModelYear == year);
        }
    }
}
