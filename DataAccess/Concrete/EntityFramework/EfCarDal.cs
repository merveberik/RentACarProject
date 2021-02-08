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
        public List<ProductDetailDto> GetProductDetail()
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.CarId equals c.BrandId
                             select new ProductDetailDto
                             {
                                 CarId = p.CarId,
                                 BrandName = c.BrandName,
                                 DailyPrice = p.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
