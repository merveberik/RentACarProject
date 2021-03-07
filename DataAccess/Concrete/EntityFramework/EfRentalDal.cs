using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarsTableContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDto()
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var result = from cust in context.Customers
                             join ca in context.Cars 
                             on cust.CustomerId equals ca.CarId
                             //join u in context.Users
                             //on cust.CustomerId equals u.UserId
                             select new RentalDetailDto
                             {
                                 CustomerId = cust.CustomerId,
                                 //FirstName = u.FirstName,
                                 //LastName = u.LastName,
                                 CompanyName = cust.CompanyName,
                                 //Email = u.Email,
                                 //Password = u.Password
                             };

                return result.ToList();
            }

        }
    }
}
