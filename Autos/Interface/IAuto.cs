using Autos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autos.Interface
{
    public interface IAuto
    {
        public List<CarSummary> GetCars();
        public bool AddCar(AddCarDetails carDetails);
    }
}
