using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class MessageManager
    {
        MessageRepository _messageRepository = new MessageRepository();

        public bool Add(Message message)
        {
            return _messageRepository.Add(message);
        }

        public Message GetById(Message message)
        {
            return _messageRepository.GetById(message);
        }

        public bool Delete(Message message)
        {
            return _messageRepository.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }
    }
}