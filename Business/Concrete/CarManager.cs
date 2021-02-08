using Business.Absrtact;
using DataAccess.Absrtact;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {

            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public void Price(Car car)
        {
            if (car.DailyPrice == 0)
            {
                Console.WriteLine("Daily price must be more than 0");
            }
            else
            {
                Console.WriteLine("You can choice a price:");
                CarManager carManager = new CarManager(new EfCarDal());

                foreach (var cars in carManager.GetAll())
                {
                    Console.WriteLine(cars.DailyPrice);
                }
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
