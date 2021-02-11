using Business.Concrete;
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
            //SpecialCarTest();
            //CarTest();
            //JoinTest(); 
            AccordingToBrandName(); 
        }

        private static void AccordingToBrandName()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("List of Brands:");
            GetAllBrand(brandManager);
            Console.WriteLine("-------- \n Please, choose a Brand Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            foreach (var cars in carManager.GetAllByBrandId(brandId))
            {
                Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
            }
        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetProductDetail())
            {

                Console.WriteLine("Car Id : " + car.CarId + "\n" + "Car Brand: " + car.BrandName + 
                                   "\n" + "Car Color: " + car.ColorName + "\n" + "Daily Price: " + car.DailyPrice +
                                     "\n" + "Model Year: " + car.ModelYear + "\n" + "Description: " + car.Description + "\n");
            }
        }

        private static void CarTest()
        {
            for (int i = 1; i < 9; i++)
            {
                CarManager carManager = new CarManager(new EfCarDal());
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                ColorManager colorManager = new ColorManager(new EfColorDal());


                Console.WriteLine("BrandId:------ {0} ------", i);
                foreach (var cars in carManager.GetAllByBrandId(i))
                {
                    Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
                }

            }
        }
        private static void SpecialCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("\nBrand Id: ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            foreach (var cars in carManager.GetAllByBrandId(brandId))
            {
                Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
            }
            //brandManager.Add(new Brand { BrandName = "a" });
            //carManager.Add(new Car { CarId = 11, BrandId = 5, ColorId = 3, DailyPrice = 700, ModelYear = 2010, Description = "Full Vehicle" });
            //carManager.Price(new Car { DailyPrice = 0 });
            //carManager.Price(new Car { DailyPrice = 100 });
            //int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            //carManager.Delete(carManager.GetById(11));
        }
        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }
        }
    }
}

