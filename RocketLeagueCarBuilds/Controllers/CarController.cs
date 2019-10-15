using Microsoft.AspNet.Identity;
using RocketLeague.Models;
using RocketLeague.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RocketLeagueCarBuilds.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userID);
            var model = service.GetCars();

            return View(model);
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCarService();

            if (service.CreateCar(model))
            {
                TempData["SaveResult"] = "Your car was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Car could not be created.");

            return View(model);
        }

        private CarService CreateCarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCarService();
            var detail = service.GetCarById(id);
            var model =
                new CarEdit
                {
                    CarID = detail.CarID,
                    CarName = detail.CarName,
                    CarColor = detail.CarColor,
                    CarRarity = detail.CarRarity,
                };
            return View(model);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CarID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCarService();

            if (service.UpdateCar(model))
            {
                TempData["SaveResult"] = "Your car was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your car could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCarService();
            var model = svc.GetCarById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCarService();

            service.DeleteCar(id);

            TempData["SaveResult"] = "Your car was deleted";

            return RedirectToAction("Index");
        }
    }
}