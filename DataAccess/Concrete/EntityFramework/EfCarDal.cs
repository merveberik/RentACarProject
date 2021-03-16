using Core.DataAccess.EntityFramework;
using Core.Entities;
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
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsTableContext>, ICarDal
    {
        public List<ProductDetailDto> GetProductDetailDto(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join brand in context.Brands
                             on car.CarId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new ProductDetailDto
                             {
                                 CarId = car.CarId,
                                 ColorId = color.ColorId,
                                 BrandId = brand.BrandId,
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
