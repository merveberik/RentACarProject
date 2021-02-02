using Business.Absrtact;
using DataAccess.Absrtact;
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
        public List<Cars> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
