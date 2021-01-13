using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class ReservationRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Reservation reservation)
        {
            int isExecuted = 0;

            _db.Reservations.Add(reservation);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }


        public Reservation GetById(Reservation reservation)
        {
            Reservation areservation = _db.Reservations.FirstOrDefault(c => c.Id == reservation.Id);
            return areservation;
        }

        public bool Delete(Reservation reservation)
        {
            int isExecuted = 0;
            Reservation areservation = _db.Reservations.FirstOrDefault(c => c.Id == reservation.Id);

            if (areservation == null)
            {
                return false;
            }

            _db.Reservations.Remove(areservation);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteBooking(Reservation reservation)
        {
            int isExecuted = 0;
            Reservation areservation = _db.Reservations.FirstOrDefault(c => c.Id == reservation.Id);

            if (areservation == null)
            {
                return false;
            }

            _db.Reservations.Remove(areservation);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Reservation> GetAll()
        {
            return _db.Reservations.ToList();
        }
    }
}