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
            //CustomerManagerTest();
            //AccordingToBrandName(); 
            GetAllCarImage();
        }
        private static void CustomerManagerTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetailDto();

            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Car Id : " + customer.CustomerId + "\n" + "Car Brand: " + customer.FirstName +
                                       "\n" + "Car Color: " + customer.LastName + "\n" + "Daily Price: " + customer.CompanyName +
                                         "\n" + "Model Year: " + customer.Email + "\n" + "Description: " + customer.Password + "\n");
                }
            }
        }
        private static void AccordingToBrandName()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //carManager.Add(new Car { CarId = 9, BrandId = 5, ColorId = 3, DailyPrice = 700, ModelYear = 2010, Description = "Full Vehicle" });

            //carManager.Delete((carManager.GetById(11)).Data);
            Console.WriteLine("List of Brands:");
            GetAllBrand(brandManager);
            Console.WriteLine("-------- \n Please, choose a Brand Id:");
            int brandId = Convert.ToInt32(Console.ReadLine());
            foreach (var cars in (carManager.GetAllByBrandId(brandId)).Data)
            {
                Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).Data.BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).Data.ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
            }
        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetProductDetailDto();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine("Car Id : " + car.CarId + "\n" + "Car Brand: " + car.BrandName +
                                       "\n" + "Car Color: " + car.ColorName + "\n" + "Daily Price: " + car.DailyPrice +
                                         "\n" + "Model Year: " + car.ModelYear + "\n" + "Description: " + car.Description + "\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
                foreach (var cars in (carManager.GetAllByBrandId(i)).Data)
                {
                    Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).Data.BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).Data.ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
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
            foreach (var cars in (carManager.GetAllByBrandId(brandId)).Data)
            {
                Console.WriteLine(cars.CarId + " \\ " + brandManager.GetById(cars.BrandId).Data.BrandName + " \\ " + colorManager.GetByColorId(cars.ColorId).Data.ColorName + " \\ " + cars.ColorId + " \\ " + cars.ModelYear + " \\ " + cars.Description + "\n");
            }
            //brandManager.Add(new Brand { BrandName = "a" });
            //carManager.Add(new Car { CarId = 11, BrandId = 5, ColorId = 3, DailyPrice = 700, ModelYear = 2010, Description = "Full Vehicle" });
            //int carIdForDelete = Convert.ToInt32(Console.ReadLine());
            carManager.Delete((carManager.GetById(11)).Data);
        }
        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + "/" + brand.BrandName);
            }
        }
        private static void GetAllCarImage()
        {
            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());
            foreach (var carImage in carImageManager.GetAll().Data)
            {
                Console.WriteLine(carImage.Id + "/" + carImage.CarId + "/" + carImage.ImagePath);
            }
        }
    }
}

