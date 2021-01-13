using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class MessageRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Message message)
        {
            int isExecuted = 0;

            _db.Messages.Add(message);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public Message GetById(Message message)
        {
            Message amessage = _db.Messages.FirstOrDefault(c => c.Id == message.Id);
            return amessage;
        }

        public bool Delete(Message message)
        {
            int isExecuted = 0;
            Message amessage = _db.Messages.FirstOrDefault(c => c.Id == message.Id);

            if (amessage == null)
            {
                return false;
            }

            _db.Messages.Remove(amessage);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Message> GetAll()
        {
            return _db.Messages.ToList();
        }
    }
}