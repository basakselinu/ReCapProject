﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ValidationTool.Validate(new CustomerValidator(), customer);

            _customerDal.Add(customer); 
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Customer>>
                    (Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>
                    (_customerDal.GetAll(),Messages.CustomerListed);
            }
        }

        public IDataResult<List<Customer>> GetAllByUserId(int id)
        {
            return new SuccessDataResult<List<Customer>>
                (_customerDal.GetAll(c => c.CustomerId == id), Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>
                    (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>
                (_customerDal.GetCustomerDetails(), Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
