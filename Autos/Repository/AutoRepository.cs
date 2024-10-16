using Autos.Interface;
using Auto.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autos.Models;

namespace Autos.Repository
{
    public class AutoRepository : IAuto
    {
        private readonly autodbContext _dbContext;
        public AutoRepository(autodbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<CarSummary> GetCars()
        {
            var cars = _dbContext.Cars
                .GroupJoin(
                        _dbContext.Gallery,
                        c => c.CarId,
                        g => g.CarId,
                        (car, galleryGroup) => new { car, galleryGroup }
                 )
                .SelectMany(
                    x => x.galleryGroup.DefaultIfEmpty(), // Perform left join
                    (x, gallery) => new CarSummary
                        {
                            CarId = x.car.CarId,
                            Manufacturer = x.car.Manufacturer,
                            RegistrationNo = x.car.RegistrationNo,
                            Model = x.car.Model,
                            Varient = x.car.Varient,
                            ManufacturingYear = x.car.ManufacturingYear,
                            RegistrationYear = x.car.RegistrationYear,
                            FuelType = x.car.FuelType,
                            Transmission = x.car.Transmission,
                            Driven = x.car.Driven,
                            Owners = x.car.Owners,
                            Sunroof = x.car.Sunroof,
                            //Thumbnail = gallery.Image,
                            CoatPrice = x.car.CoatPrice,
                            ImageName = x.car.RegistrationNo.Replace(" ","").ToLower()
                    }).ToList();
            return cars;
        }

        public bool AddCar(AddCarDetails carDetails)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Car car = new Car()
                    {
                        CarId = Guid.NewGuid(),
                        RegistrationNo = carDetails.RegistrationNo,
                        Manufacturer = carDetails.Manufacturer,
                        Model = carDetails.Model,
                        Varient = carDetails.Varient,
                        ManufacturingYear = carDetails.ManufacturingYear,
                        RegistrationYear = carDetails.RegistrationYear ?? carDetails.ManufacturingYear,
                        FuelType = carDetails.FuelType,
                        Transmission = carDetails.Transmission,
                        Driven = carDetails.Driven,
                        Owners = carDetails.Owners,
                        Sunroof = carDetails.Sunroof,
                        InsuranceExpiry = carDetails.InsuranceExpiry,
                        InsuranceType = carDetails.InsuranceType,
                        Alloys = carDetails.Alloys,
                        Colour = carDetails.Colour,
                        Seats = carDetails.Seats,
                        Doors = carDetails.Doors,
                        Description = carDetails.Description,
                        CoatPrice = carDetails.CoatPrice,                        
                    };
                    Gallery gallery = new Gallery()
                    {
                        GalleryId = Guid.NewGuid(),
                        CarId = car.CarId,
                        ImageType = "Car",
                        Image = carDetails.CarImage
                    };
                    _dbContext.Cars.Add(car);
                    _dbContext.Gallery.Add(gallery);
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
