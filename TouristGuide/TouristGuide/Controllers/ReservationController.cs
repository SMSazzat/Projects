using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class ReservationController : Controller
    {

        ReservationManager _reservationManager = new ReservationManager();
        Reservation _reservation = new Reservation();
        Reservation _showReservation = new Reservation();
        RegistrationManager _registrationManager = new RegistrationManager();

        [HttpGet]
        public ActionResult Add()
        {
            return View(_reservation);
        }

        [HttpPost]
        public ActionResult Add(Reservation reservation)
        {
            reservation.PackageId = reservation.PackageId;
            if (_reservationManager.Add(reservation))
            {
                ViewBag.successMsg = "Booking Confirmed";
            }

            else
            {
                ViewBag.failMsg = "Failed to book";
            }
            return View(reservation);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _reservation.Id = id;
            var areservation = _reservationManager.GetById(_reservation);
            return View(areservation);
        }

        [HttpPost]
        public ActionResult Delete(Reservation reservation)
        {
            if (_reservationManager.Delete(reservation))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(reservation);
        }

        public ActionResult Show()
        {
            _reservation.Reservations = _reservationManager.GetAll();
            if (_reservation.Reservations.Count == 0)
            {
                ViewBag.Msg = "No Reservation found";
            }
            return View(_reservation);
        }

        [HttpGet]
        public ActionResult UserLogin(int id)
        {
            _reservation.PackageId = id;
            return View(_reservation);
        }

        [HttpPost]
        public ActionResult UserLogin(int id, string userName, string password, string name, string pass, string email)
        {


            if ((userName != null) && (password != null))
            {
                var users = _registrationManager.GetAll();
                users = users.Where(c => c.UserName == userName && c.Password == password).ToList();

                if (users.Count > 0)
                {
                    _reservation.PackageId = id;
                    foreach (var uId in users)
                    {
                        _reservation.UserId = uId.Id;
                    }

                    return RedirectToAction("Add", _reservation);
                }
            }


            if ((name != null) && (pass != null) && (email != null))
            {
                Registration registration = new Registration();
                registration.Email = email;
                registration.UserName = name;
                registration.Password = pass;
                if (_registrationManager.Add(registration))
                {
                    _reservation.PackageId = id;
                    return RedirectToAction("Add", _reservation);
                }
            }

            else
            {
                _reservation.PackageId = id;
                ViewBag.msg = "Wrong userName or Password";
            }
            return View(_reservation);
        }

        [HttpGet]
        public ActionResult MyBooking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyBooking(string username, string password)
        {
            if ((username != null) && (password != null))
            {
                var users = _registrationManager.GetAll();
                users = users.Where(c => c.UserName == username && c.Password == password).ToList();

                if (users.Count > 0)
                {

                    foreach (var uId in users)
                    {
                        _reservation.UserId = uId.Id;
                    }

                    return RedirectToAction("ShowBooking", _reservation);
                }
                else
                    ViewBag.wrong = "Wrong User Name or Password";
            }
            return View();
        }

        public ActionResult ShowBooking(Reservation reservation)
        {
            var reservations = _reservationManager.GetAll();
            reservations = reservations.Where(c => c.UserId == reservation.UserId).ToList();
            _reservation.Reservations = reservations;
            if (_reservation.Reservations.Count == 0)
            {
                return RedirectToAction("NotFound");
            }
            return View(_reservation);

        }

        public ActionResult DeleteBooking(Reservation reservation)
        {
            _reservationManager.DeleteBooking(reservation);
            return RedirectToAction("ShowBooking", reservation);
        }

        public ActionResult NotFound()
        {
            ViewBag.msg = "Currently you do not have any booking";
            return View();
        }


    }
}
