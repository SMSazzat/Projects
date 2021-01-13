using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class RescueTeamController : Controller
    {
        RescueTeam _rescueTeam = new RescueTeam();
        RescueTeamManager _rescueTeamManager = new RescueTeamManager();
        DistrictManager _districtManager = new DistrictManager();

        [HttpGet]
        public ActionResult Add()
        {
            RescueTeam rescueTeam = new RescueTeam();
            rescueTeam.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(rescueTeam);
        }

        [HttpPost]
        public ActionResult Add(RescueTeam rescueTeam)
        {

            if (_rescueTeamManager.Add(rescueTeam))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            rescueTeam.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(rescueTeam);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _rescueTeam.Id = id;
            var arescueTeam = _rescueTeamManager.GetById(_rescueTeam);
            arescueTeam.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(arescueTeam);
        }

        [HttpPost]
        public ActionResult Update(RescueTeam rescueTeam)
        {

            if (_rescueTeamManager.Update(rescueTeam))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Update Failed";
            }


            rescueTeam.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(rescueTeam);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _rescueTeam.Id = id;
            var arescueTeam = _rescueTeamManager.GetById(_rescueTeam);
            return View(arescueTeam);
        }


        [HttpPost]
        public ActionResult Delete(RescueTeam rescueTeam)
        {
            if (_rescueTeamManager.Delete(rescueTeam))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(rescueTeam);
        }


        [HttpGet]
        public ActionResult Show()
        {
            _rescueTeam.RescueTeams = _rescueTeamManager.GetAll();
            if (_rescueTeam.RescueTeams.Count == 0)
            {
                ViewBag.Msg = "No Rescue Team found";
            }
            return View(_rescueTeam);
        }


        [HttpPost]
        public ActionResult Show(string name)
        {
            var rescueTeams = _rescueTeamManager.GetAll();

            if (name != null)
            {
                rescueTeams = rescueTeams.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _rescueTeam.RescueTeams = rescueTeams;
            return View(_rescueTeam);
        }

        [HttpGet]
        public ActionResult ShowRescueTeam()
        {
            _rescueTeam.RescueTeams = _rescueTeamManager.GetAll();
            if (_rescueTeam.RescueTeams.Count == 0)
            {
                ViewBag.Msg = "No Rescue Team found";
            }
            return View(_rescueTeam);
        }


        [HttpPost]
        public ActionResult ShowRescueTeam(string district)
        {
            var rescueTeams = _rescueTeamManager.GetAll();

            if (district != null)
            {
                rescueTeams = rescueTeams.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _rescueTeam.RescueTeams = rescueTeams;
            if (_rescueTeam.RescueTeams.Count > 0)
                return View(_rescueTeam);
            else
                return RedirectToAction("NotFound");
        }

        public ActionResult NotFound()
        {
            ViewBag.msg = "Nothing found related to your search";
            return View();
        }
    }
}