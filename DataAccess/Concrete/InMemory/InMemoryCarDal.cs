using DataAccess.Absrtact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Cars> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Cars>
            {
                new Cars{BrandId = 1, CarId = 1, Color = "Black", DailyPrice=1500, ModelYear =2010, Description="Suzuki Vitara -> SUV"},
                new Cars{BrandId = 1, CarId = 2, Color = "White", DailyPrice=1000, ModelYear =2000, Description="Hyundai Kona -> SUV - 2-door"},
                new Cars{BrandId = 2, CarId = 3, Color = "Red", DailyPrice=1250, ModelYear =2002, Description="C-5 -> Hatcback"},
                new Cars{BrandId = 3, CarId = 2, Color = "Black", DailyPrice=1750, ModelYear =2017, Description="VAN"},
                new Cars{BrandId = 4, CarId = 1, Color = "Blue", DailyPrice=1500, ModelYear =2020, Description="All Terrain Vehicle"},

            };
        }
        public void Add(Cars cars)
        {
            _cars.Add(cars);
        }

        public void Delete(Cars cars)
        {
            Cars carsToDelete = _cars.SingleOrDefault(c => c.CarId == cars.CarId);
            _cars.Remove(cars);
        }

        public List<Cars> GetAllByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Cars> GetAll()
        {
            return _cars;
        }

        public void Update(Cars cars)
        {
            Cars carsToUpdate = _cars.SingleOrDefault(c => c.CarId == cars.CarId);
            carsToUpdate.CarId = cars.CarId;
            carsToUpdate.BrandId = cars.BrandId;
            carsToUpdate.Color = cars.Color;
            carsToUpdate.DailyPrice = cars.DailyPrice;
            carsToUpdate.ModelYear = cars.ModelYear;
        }
    }
}
