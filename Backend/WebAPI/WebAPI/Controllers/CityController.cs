using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.Repo;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;
        private readonly ICityRepository repo;

        public CityController(DataContext dc, ICityRepository repo)
        {
            this.dc = dc;
            this.repo = repo;
        }

        //Get  api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await repo.GetCitiesAsync();
            return Ok(cities); 
        }

        //Post api/city/add?cityname=chilaw
        //[HttpPost("add")]

        //Post api/city/add/Moratuwa
        //[HttpPost("add/{cityName}")]

        //public async Task<IActionResult> AddCity(string cityName)
      //  public async Task<IActionResult> AddCity(string cityName)
       // {
         //   City city = new City();
        //    city.name = cityName;
        //    await dc.Cities.AddAsync(city);
         //   await dc.SaveChangesAsync();
         //   return Ok(city);
       // }

        //Post api/city/post --Post the data in JSON format--
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            repo.AddCity(city);
            await repo.SaveAsync();
            return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            repo.DeleteCity(id);
            await repo.SaveAsync();
            return Ok(id);
        }
    }
}
