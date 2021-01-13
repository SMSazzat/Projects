using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital

        HospitalManager _hospitalManager = new HospitalManager();
        DistrictManager _districtManager = new DistrictManager();
        Hospital _hospital = new Hospital();
        Hospital _showHospital = new Hospital();

        [HttpGet]
        public ActionResult Add()
        {
            Hospital hospital = new Hospital();
            hospital.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(hospital);
        }

        [HttpPost]
        public ActionResult Add(Hospital hospital)
        {
            string fileName = Path.GetFileNameWithoutExtension(hospital.ImageFile.FileName);
            string extension = Path.GetExtension(hospital.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            hospital.Image = "~/Image/Hospitals/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Hospitals/"), fileName);
            hospital.ImageFile.SaveAs(fileName);

            if (_hospitalManager.Add(hospital))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            hospital.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(hospital);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _hospital.Id = id;
            var ahospital = _hospitalManager.GetById(_hospital);
            ahospital.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(ahospital);
        }

        [HttpPost]
        public ActionResult Update(Hospital hospital)
        {
            string fileName = Path.GetFileNameWithoutExtension(hospital.ImageFile.FileName);
            string extension = Path.GetExtension(hospital.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            hospital.Image = "~/Image/Hospitals/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Hospitals/"), fileName);
            hospital.ImageFile.SaveAs(fileName);


                if (_hospitalManager.Update(hospital))
                {
                    ViewBag.successMsg = "Updated";
                }

                else
                {
                    ViewBag.failMsg = "Upadte failed";
                }


            hospital.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(hospital);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            _hospital.Id = id;
            var ahospital = _hospitalManager.GetById(_hospital);
            return View(ahospital);
        }

        [HttpPost]
        public ActionResult Delete(Hospital hospital)
        {
            if (_hospitalManager.Delete(hospital))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(hospital);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _hospital.Hospitals = _hospitalManager.GetAll();
            if (_hospital.Hospitals.Count == 0)
            {
                ViewBag.Msg = "No hospital found";
            } 
            return View(_hospital);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var hospitals = _hospitalManager.GetAll();

            if(name != null)
            {
                hospitals = hospitals.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _hospital.Hospitals = hospitals;
            return View(_hospital);
        }

        [HttpGet]
        public ActionResult ShowHospital()
        {
            _hospital.Hospitals = _hospitalManager.GetAll();
            if (_hospital.Hospitals.Count == 0)
            {
                ViewBag.Msg = "No hospital found";
            }
            return View(_hospital);
        }

        [HttpPost]
        public ActionResult ShowHospital(string district)
        {
            var hospitals = _hospitalManager.GetAll();

            if (district != null)
            {
                hospitals = hospitals.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _hospital.Hospitals = hospitals;
            if (_hospital.Hospitals.Count > 0)
                return View(_hospital);
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