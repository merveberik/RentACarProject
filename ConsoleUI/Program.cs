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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("BrandId:------ 1 ------");
            foreach (var cars in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description +"\n");
            }
            Console.WriteLine("BrandId:------ 2 ------");
            foreach (var cars in carManager.GetAllByBrandId(2))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description + "\n");
            }
            Console.WriteLine("BrandId:------ 4 ------");
            foreach (var cars in carManager.GetAllByBrandId(4))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description + "\n");
            }
            Console.WriteLine("BrandId:------ 5 ------");
            foreach (var cars in carManager.GetAllByBrandId(5))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description + "\n");
            }
            Console.WriteLine("BrandId:------ 6 ------");
            foreach (var cars in carManager.GetAllByBrandId(6))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description + "\n");
            }
            Console.WriteLine("BrandId:------ 7 ------");
            foreach (var cars in carManager.GetAllByBrandId(7))
            {
                Console.WriteLine(cars.CarId + " --- " + brandManager.GetById(cars.BrandId).BrandName + " --- " + colorManager.GetByColorId(cars.ColorId).ColorName + " --- " + cars.ColorId + " --- " + cars.ModelYear + " --- " + cars.Description + "\n");
            }
            brandManager.Add(new Brand { BrandName = "a" });
            carManager.Price(new Car { DailyPrice = 0 });
            carManager.Price(new Car { DailyPrice = 100 });
        }
    }
}

