using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Absrtact;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsTableContext>, ICarDal
    {
        public List<ProductDetailDto> GetProductDetailDto()
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.CarId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new ProductDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }
    }
}
