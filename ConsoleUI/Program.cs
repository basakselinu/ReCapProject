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

            CarManager carManager = new CarManager(new EfCarDal());
            //CarTest(carManager);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Sarı" });
            colorManager.Add(new Color { ColorName = "Pembe" });
            colorManager.Add(new Color { ColorName = "Mavi" });
            //ColorTest(colorManager);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Lamborghini" });
            brandManager.Add(new Brand { BrandName = "Ford" });
            BrandTest(brandManager);

        }

        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine("-----GetAll-----");
            foreach (var brand in brandManager.GetAll())
            {

                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("\n");

            Console.WriteLine("-----GetById-----");
            var getBrandId = brandManager.GetById(4);
            Console.WriteLine(getBrandId.BrandName);
        }

        private static void ColorTest(ColorManager colorManager)
        {
            Console.WriteLine("-----GetAll-----");
            foreach (var color in colorManager.GetAll())
            {

                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("\n");

            Console.WriteLine("-----GetById-----");
            var getColorId = colorManager.GetById(2);
            Console.WriteLine(getColorId.ColorName);
        }

        private static void CarTest(CarManager carManager)
        {
            Console.WriteLine("-----GetAll-----");
            foreach (var car in carManager.GetAll())
            {

                Console.WriteLine(car.Descriptions);
            }
            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarsByBrandId-----");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Descriptions);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarsByColorId-----");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Descriptions);
            }

            Console.WriteLine("\n");

            Console.WriteLine("-----GetCarDetails-----");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(
                    "Car Name: " + car.CarName + " Brand Name: " + car.BrandName +
                    " Color Name: " + car.ColorName + " Daily Price: " + car.DailyPrice);
            }
        }
    }
}