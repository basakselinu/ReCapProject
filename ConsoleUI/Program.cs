using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car car1 = new Car();
            //car1.CarId = 6;
            //car1.BrandId = 2;
            //car1.ColorId = 1;
            //car1.Descriptions = "Renault R9";
            //car1.DailyPrice = 205000;
            //car1.ModelYear = 1999;

            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //carManager.Add(car1);
            //car1.Descriptions = "Renault R99";
            //carManager.Update(car1);
            //carManager.Delete(car1);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Descriptions);
            //}


            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
          
            
            foreach (var car in carManager.GetAll())
            {
                
                Console.WriteLine(car.Descriptions);
            }

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Descriptions);
            }

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Descriptions);
            }

        }
    }
}