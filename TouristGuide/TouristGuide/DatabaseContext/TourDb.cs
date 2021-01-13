using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TouristGuide.Models;

namespace TouristGuide.DatabaseContext
{
    public class TourDb:DbContext
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<RentCar> RentCars { get; set; }
        public DbSet<RescueTeam> RescueTeams { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ShoppingMall> ShoppingMalls { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public DbSet<NearestSpot> NearestSpots { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}