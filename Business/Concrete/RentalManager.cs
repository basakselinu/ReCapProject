using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //Araba daha önceden kiralandı mı? , Araba teslim edildi mi?
            var rentACar = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate==null);
            if (rentACar == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                    return new ErrorResult();         
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>
                (_rentalDal.GetAll());
            }          
        }

        public IDataResult<List<Rental>> GetAllByCarId(int id)
        {
            return new SuccessDataResult<List<Rental>>
                (_rentalDal.GetAll(r=>r.CarId==id));
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>
                (_rentalDal.GetAll(r=>r.CustomerId==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<RentalDetailDto>>
                    (Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>
                (_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
