using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Descriptions.Length>=2 && car.DailyPrice>0)
            {
                //Console.WriteLine("Araba Başarıyla Eklendi.");
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba Eklenemedi.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //Console.WriteLine("---Arabalar Listelendi---\n");
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
           return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            //Console.WriteLine("---Arabalar Markaya Göre Filtrelendi---\n");
            return _carDal.GetAll(c=>c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
           // Console.WriteLine("---Arabalar Renge Göre Filtrelendi---\n");
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}