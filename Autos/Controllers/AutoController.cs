using Autos.Interface;
using Autos.Models;
using Autos.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Auto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAuto _repo;

        public AutoController (IAuto repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetCars")]
        public IActionResult GetCars()
        {
            return Ok(_repo.GetCars());
        }

        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar([FromBody] AddCarDetails carDetails)
        {
            return Ok(_repo.AddCar(carDetails));
        }


        //public JsonResult GetCars()
        //{
        //    string query = "SELECT * FROM CARS";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("autodb");
        //    SqlDataReader myReader;

        //    using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
        //    {
        //        sqlConnection.Open();
        //        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection)
        //        {
        //            myReader = sqlCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            sqlConnection.Close();
        //        }
        //    }
        //   return new JsonResult(table);
        //}
    }
}
