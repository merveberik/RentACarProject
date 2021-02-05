using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var addedBrand = context.Entry(entity);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var deletedBrand = context.Entry(entity);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (CarsTableContext context = new CarsTableContext())
            {
                var updatedBrand = context.Entry(entity);
                updatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
