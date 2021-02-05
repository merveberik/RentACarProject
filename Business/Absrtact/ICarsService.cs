using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
    public interface ICarsService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int id);
        List<Car> GetByDailyPrice(decimal min, decimal max);
        void Price(Car car);
    }
}
