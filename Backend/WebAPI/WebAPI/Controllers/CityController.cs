using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        //Get  api/city
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
           // var citiesDto = from c in cities
                      //      select new CityDto()
                      //      {
                       //         Id = c.Id,
                       //         name = c.name
                       //     };
            return Ok(citiesDto); 
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
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            //var city = new City
            //{
            //    name = cityDto.name,
            //    LastUpdateBy = 1,
            //    LastUpdateOn = DateTime.Now

            //};

            var city = mapper.Map<City>(cityDto);
            city.LastUpdateBy = 1;
            city.LastUpdateOn = DateTime.Now;
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
