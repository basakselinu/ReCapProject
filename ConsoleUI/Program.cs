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

            CarTest();
            //ColorTest();
            //BrandTest();

        }

        private static void BrandTest()
        {
            Console.WriteLine("-----GetAll-----");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetById-----");
            var getBrandId = brandManager.GetById(1);
            Console.WriteLine(getBrandId.Data.BrandName);
        }

        private static void ColorTest()
        {
            Console.WriteLine("-----GetAll-----");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("\n");

            Console.WriteLine("-----GetById-----");
            var getColorId = colorManager.GetById(1);
            Console.WriteLine(getColorId.Data.ColorName);

        }

        private static void CarTest()
        {
            Console.WriteLine("-----GetAll-----");
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Descriptions);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarsByBrandId-----");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Descriptions);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarsByColorId-----");
            foreach (var car in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine(car.Descriptions);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarDetails-----");
            var getCarDetails = carManager.GetCarDetails();
            if (getCarDetails.Success == true)
            {
                foreach (var car in getCarDetails.Data )
                {
                    Console.WriteLine(
                        "Car Name: " + car.CarName + " Brand Name: " + car.BrandName +
                        " Color Name: " + car.ColorName + " Daily Price: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(getCarDetails.Message);   
            }
        }
    }
}