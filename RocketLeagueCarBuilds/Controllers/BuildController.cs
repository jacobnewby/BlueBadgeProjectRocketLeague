using RocketLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RocketLeague.Services;
using Microsoft.AspNet.Identity;

namespace RocketLeague.Controllers
{
    [Authorize]
    public class BuildController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            var model = service.GetBuilds();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            CarService serviceCar = new CarService(userId);
            ViewBag.Cars = serviceCar.GetCars();
            DecalService serviceDecal = new DecalService(userId);
            ViewBag.Decals = serviceDecal.GetDecals();
            WheelsService serviceWheels = new WheelsService(userId);
            ViewBag.Wheelss = serviceWheels.GetWheels();
            GoalService serviceGoal = new GoalService(userId);
            ViewBag.Goals = serviceGoal.GetGoals();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildCreate model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            CarService serviceCar = new CarService(userId);
            ViewBag.Cars = serviceCar.GetCars();
            DecalService serviceDecal = new DecalService(userId);
            ViewBag.Decals = serviceDecal.GetDecals();
            WheelsService serviceWheels = new WheelsService(userId);
            ViewBag.Wheelss = serviceWheels.GetWheels();
            GoalService serviceGoal = new GoalService(userId);
            ViewBag.Goals = serviceGoal.GetGoals();

            if (!ModelState.IsValid) return View(model);

            var service = CreateBuildService();

            if (service.CreateBuild(model))
            {
                TempData["SaveResult"] = "Your build was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Build could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBuildService();
            var model = svc.GetBuildById(id);

            return View(model);
        }

        private BuildService CreateBuildService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuildService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBuildService();
            var detail = service.GetBuildById(id);
            var userId = Guid.Parse(User.Identity.GetUserId());
            CarService serviceCar2 = new CarService(userId);
            ViewBag.Cars = serviceCar2.GetCars();
            DecalService serviceDecal2 = new DecalService(userId);
            ViewBag.Decals = serviceDecal2.GetDecals();
            WheelsService serviceWheels2 = new WheelsService(userId);
            ViewBag.Wheelss = serviceWheels2.GetWheels();
            GoalService serviceGoal2 = new GoalService(userId);
            ViewBag.Goals = serviceGoal2.GetGoals();

            var model =
                new BuildEdit
                {
                    BuildID = detail.BuildID,
                    BuildName = detail.BuildName,
                    
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuildEdit model)
        {
            var service = CreateBuildService();
            var detail = service.GetBuildById(id);
            var userId = Guid.Parse(User.Identity.GetUserId());
            CarService serviceCar2 = new CarService(userId);
            ViewBag.Cars = serviceCar2.GetCars();
            DecalService serviceDecal2 = new DecalService(userId);
            ViewBag.Decals = serviceDecal2.GetDecals();
            WheelsService serviceWheels2 = new WheelsService(userId);
            ViewBag.Wheelss = serviceWheels2.GetWheels();
            GoalService serviceGoal2 = new GoalService(userId);
            ViewBag.Goals = serviceGoal2.GetGoals();

            if (!ModelState.IsValid) return View(model);

            if (model.BuildID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service2 = CreateBuildService();

            if (service2.UpdateBuild(model))
            {
                TempData["SaveResult"] = "Your build was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your build could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBuildService();
            var model = svc.GetBuildById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBuildService();

            service.DeleteBuild(id);

            TempData["SaveResult"] = "Your build was deleted";

            return RedirectToAction("Index");
        }
    }
}