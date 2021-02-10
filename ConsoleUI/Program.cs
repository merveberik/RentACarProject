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
            JoinTest(); 
        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetProductDetail())
            {
                Console.WriteLine(car.CarId + "/" + car.BrandName);
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
            brandManager.Add(new Brand { BrandName = "a" });
            carManager.Add(new Car { CarId = 3, BrandId = 4, ColorId = 2, DailyPrice = 650, ModelYear = 2015, Description = "Full vehice" });
            carManager.Price(new Car { DailyPrice = 0 });
            carManager.Price(new Car { DailyPrice = 100 });
        }
    }
}

