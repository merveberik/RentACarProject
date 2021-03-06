﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
//using Business.CCS;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarOfCategoryCorrect(car.CarId));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin,car.admin")]
        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.ProductDeleted);
            }
            catch (ArgumentNullException)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_carDal.GetProductDetailDto(c => c.ColorId == id));  //eşit olan id leri filtrele demek
        }
        public IDataResult<List<ProductDetailDto>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_carDal.GetProductDetailDto(c => c.ColorId == id));
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c => c.CarId == carId));
        }
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_carDal.GetProductDetailDto());
        }

        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("admin,car.admin")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.ProductUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
        }

        public IDataResult<Car> GetModelYear(int year)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ModelYear == year));
        }

        private IResult CheckIfCarOfCategoryCorrect(int carId)
        {
            var result = _carDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);

            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            _carDal.Add(car);
            _carDal.Update(car);
            return null;
        }
    }
}
