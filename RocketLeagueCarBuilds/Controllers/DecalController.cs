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
    public class DecalController : Controller
    {
        // GET: Decal
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DecalService(userID);
            var model = service.GetDecals();

            return View(model);
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DecalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDecalService();

            if (service.CreateDecal(model))
            {
                TempData["SaveResult"] = "Your decal was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Decal could not be created.");

            return View(model);
        }

        private DecalService CreateDecalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DecalService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDecalService();
            var detail = service.GetDecalById(id);
            var model =
                new DecalEdit
                {
                    DecalID = detail.DecalID,
                    DecalName = detail.DecalName,
                    DecalColor = detail.DecalColor,
                     DecalRarity = detail.DecalRarity,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DecalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DecalID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDecalService();

            if (service.UpdateDecal(model))
            {
                TempData["SaveResult"] = "Your decal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your decal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDecalService();
            var model = svc.GetDecalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDecalService();

            service.DeleteDecal(id);

            TempData["SaveResult"] = "Your Decal was deleted";

            return RedirectToAction("Index");
        }
    }
}