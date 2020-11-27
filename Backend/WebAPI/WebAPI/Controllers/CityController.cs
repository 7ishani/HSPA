using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //Get  api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();
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
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
