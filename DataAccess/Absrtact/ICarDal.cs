using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Absrtact
{
    public interface ICarDal
    {
        List<Cars> GetAll();
        void Add(Cars cars);
        void Update(Cars cars);
        void Delete(Cars cars);
        List<Cars> GetAllByBrandId(int BrandId);
    }
}
