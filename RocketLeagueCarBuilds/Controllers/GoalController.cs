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
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userID);
            var model = service.GetGoals();

            return View(model);
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GoalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGoalService();

            if (service.CreateGoal(model))
            {
                TempData["SaveResult"] = "Your goal was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Goal could not be created.");

            return View(model);
        }

        private GoalService CreateGoalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGoalService();
            var detail = service.GetGoalById(id);
            var model =
                new GoalEdit
                {
                    GoalID = detail.GoalID,
                    GoalName = detail.GoalName,
                    GoalColor = detail.GoalColor,
                    GoalRarity = detail.GoalRarity,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GoalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GoalID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGoalService();

            if (service.UpdateGoal(model))
            {
                TempData["SaveResult"] = "Your goal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your goal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGoalService();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGoalService();

            service.DeleteGoal(id);

            TempData["SaveResult"] = "Your goal was deleted";

            return RedirectToAction("Index");
        }
    }
}