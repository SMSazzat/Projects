using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class ReservationManager
    {
        ReservationRepository _reservationRepository = new ReservationRepository();

        public bool Add(Reservation reservation)
        {
            return _reservationRepository.Add(reservation);
        }

        public Reservation GetById(Reservation reservation)
        {
            return _reservationRepository.GetById(reservation);
        }

        public bool Delete(Reservation reservation)
        {
            return _reservationRepository.Delete(reservation);
        }

        public bool DeleteBooking(Reservation reservation)
        {
            return _reservationRepository.DeleteBooking(reservation);
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }
    }
}