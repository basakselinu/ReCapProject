using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=1000000,Description="Honda Civic",ModelYear=2018},
                new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=1040000,Description="Renault Megane",ModelYear=2021},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=1780000,Description="Volkswagen Passat",ModelYear=2017},
                new Car{CarId=4,BrandId=1,ColorId=2,DailyPrice=615000,Description="Honda Jazz",ModelYear=2007},
                new Car{CarId=5,BrandId=4,ColorId=2,DailyPrice=1049999,Description="Audi A3",ModelYear=2015}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.BrandId==id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            carToUpdate.Description =car.Description;
            carToUpdate.DailyPrice =car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}
