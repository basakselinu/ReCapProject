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

            //CarTest();
            //ColorTest();
            //BrandTest();
            RentalTest();
            //UserTest();
            //CustomerTest();


        }
        private static void CustomerTest()
        {
            Console.WriteLine("-----GetAll-----");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
               CompanyName="Ünsal Yazılım",
               UserId=1
               
            });

            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void UserTest()
        {
            Console.WriteLine("-----GetAll-----");
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Başak Selin",
                LastName = "Ünsal",
                Email = "basak@gmail.com",
                Password = "12345"
            });

            var result = userManager.GetAll();
            if (result.Success==true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName+" "+user.LastName+" -- "+user.Email);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void RentalTest()
        {
            Console.WriteLine("-----GetAll-----");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(
                        rental.CarName+" -- "+
                        rental.CustomerName+" -- "+
                        rental.RentDate.Date.ToString("dd MM yyyy")+" -- "+
                        rental.ReturnDate.ToString()
                        );
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }           
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