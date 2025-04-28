using CarGallery_ef.DAL;
using CarGallery_ef.Models;
using CarGallery_ef.Services;

namespace CarGallery_ef;

internal class Program
{
    static void Main(string[] args)
    {
        AppDbContext appDbContext = new AppDbContext();
        GenericService<Customer> customerService = new(appDbContext);
        //customerService.Add(new Customer { Name = "John", Surname = "Doe", PhoneNumber = "123456789" });

        GenericService<Car> carService = new(appDbContext);
        //carService.Add(new Car { Model = "A8", DailyPrice = 200, Year = 2005, Brand = "Audi", IsAvailable = true });
        //carService.Add(new Car { Model = "A6", DailyPrice = 150, Year = 2008, Brand = "Audi", IsAvailable = false });
        //carService.Add(new Car { Model = "A4", DailyPrice = 120, Year = 2010, Brand = "Audi", IsAvailable = false });
        //carService.Add(new Car { Model = "A3", DailyPrice = 90, Year = 2015, Brand = "Audi", IsAvailable = true });
        //carService.Add(new Car { Model = "A2", DailyPrice = 80, Year = 2018, Brand = "Audi", IsAvailable = true });
        //carService.Add(new Car { Model = "A1", DailyPrice = 70, Year = 2020, Brand = "Audi", IsAvailable = true });

        GenericService<Rental> rentalService = new(appDbContext);
        //rentalService.Add(new Rental
        //{
        //    RentalDate = DateTime.Now,
        //    ReturnDate = DateTime.Now,
        //    CarId = 13,
        //    CustomerId = 6
        //});
        //Car updatedCar = carService.Find(13);
        //Console.WriteLine(updatedCar.Id);
        //updatedCar.IsAvailable = false;
        //carService.Update(updatedCar);


        //Rental updatedRental = rentalService.Find(1);
        //Console.WriteLine(updatedRental.CarId);
        //Car returnedCar = carService.Find(updatedRental.CarId);
        //returnedCar.IsAvailable = true;
        //updatedRental.ReturnDate = DateTime.Now;
        //carService.Update(returnedCar);
        //rentalService.Update(updatedRental);

        foreach (var rental in rentalService.Get().ToList())
        {
            rental.Customer= customerService.Find(rental.CustomerId);
            rental.Car = carService.Find(rental.CarId);
            Console.WriteLine("{0} {1} - {2}",rental.Customer.Name, rental.Customer.Surname, rental.Car.Model); 
            Console.WriteLine(); 
        }

    }
}
/*1.Yeni maşın əlavə et.

2.Yeni müştəri əlavə et.

3.Mövcud olan (IsAvailable = true olan) maşınları siyahıla.

4.Müştəriyə maşın kirayə ver (RentDate bugünkü gün olsun və maşının mövcudluğu d
əyişsin).

5.Maşını geri qaytar(ReturnDate doldurulsun və maşın yenidən mövcud olsun).

6.Bütün kirayə qeydlərini siyahıla(müştəri və maşın adları ilə birlikdə).*/