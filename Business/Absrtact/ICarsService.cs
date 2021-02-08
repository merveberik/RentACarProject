using Entities.Concrete;
using Entities.DTOs;
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
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<ProductDetailDto> GetProductDetail();


    }
}
