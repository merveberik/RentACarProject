using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarsService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetModelYear(int year);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<ProductDetailDto>> GetProductDetailDto();
        IDataResult<List<ProductDetailDto>> GetAllByBrandId(int id);
        IDataResult<List<ProductDetailDto>> GetAllByColorId(int id);
        IResult AddTransactionTest(Car car);


    }
}
