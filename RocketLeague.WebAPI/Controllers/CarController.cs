using Microsoft.AspNet.Identity;
using RocketLeague.Models;
using RocketLeague.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RocketLeague.WebAPI.Controllers
{
    public class CarController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            CarService carService = CreateCarService();
            var cars = carService.GetCars();
            return Ok(cars);
        }

        public IHttpActionResult Get(int id)
        {
            CarService carService = CreateCarService();
            var car = carService.GetCarById(id);
            return Ok(car);
        }

        public IHttpActionResult Post(CarCreate car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCarService();

            if (!service.CreateCar(car))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CarEdit car)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCarService();

            if (!service.UpdateCar(car))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCarService();

            if (!service.DeleteCar(id))
                return InternalServerError();

            return Ok();
        }

        private CarService CreateCarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new CarService(userId);
            return noteService;
        }
    }
}
