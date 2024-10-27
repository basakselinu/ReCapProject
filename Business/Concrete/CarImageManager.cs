using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(formFile, PathContants.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelperService.Delete(PathContants.ImagePath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(formFile, PathContants.ImagePath, PathContants.ImagePath + carImage.ImagePath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(
                _carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(
                 _carImageDal.Get(c => c.CarImageId == carImageId),
                 Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(
                 _carImageDal.GetAll(c => c.CarId == id),
                 Messages.CarImageListed);
        }
        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);

            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            var result=_carImageDal.GetAll(c=>c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessDataResult<List<CarImage>>(Messages.CarImageListed);
            }

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage
            {
                CarId = carId,
                ImagePath="defaultImage.jpg",
            });
            return new ErrorDataResult<List<CarImage>>(carImage);
        }
    }
}
