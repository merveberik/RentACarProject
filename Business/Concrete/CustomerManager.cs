using Business.Absrtact;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Absrtact;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (_customerDal.Get(c => c.CustomerId == customer.CustomerId) == null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }

            return new ErrorResult(Messages.CustomerInvalid);
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch (ArgumentNullException)
            {
                return new ErrorResult(Messages.CustomerInvalid);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id)); 
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult(Messages.CustomerUpdated);
        }
        //public IDataResult<List<CustomerDetailDto>> GetCustomerDetailDto()
        //{
        //    return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetailDto());
        //}
    }
}
