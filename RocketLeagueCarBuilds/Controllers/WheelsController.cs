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
    public class WheelsController : Controller
    {
        // GET: Wheels
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new WheelsService(userID);
            var model = service.GetWheels();

            return View(model);
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WheelsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWheelsService();

            if (service.CreateWheels(model))
            {
                TempData["SaveResult"] = "Your wheels were created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Wheels could not be created.");

            return View(model);
        }

        private WheelsService CreateWheelsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WheelsService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateWheelsService();
            var detail = service.GetWheelsById(id);
            var model =
                new WheelsEdit
                {
                    WheelsID = detail.WheelsID,
                    WheelsName = detail.WheelsName,
                    WheelsColor = detail.WheelsColor,
                    WheelsRarity = detail.WheelsRarity,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WheelsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WheelsID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateWheelsService();

            if (service.UpdateWheels(model))
            {
                TempData["SaveResult"] = "Your wheels were updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your wheels could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWheelsService();
            var model = svc.GetWheelsById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWheelsService();

            service.DeleteWheels(id);

            TempData["SaveResult"] = "Your wheels were deleted";

            return RedirectToAction("Index");
        }
    }
}