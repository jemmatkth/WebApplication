using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models.ViewModels
{
    public class MessageViewModel
    {
        public List<Message> Messages { get; set; }
        public Message Message { get; set; }
        public int numberOfTotalMessages { get; set; }
        public MessageStatus Status { get; set; }
    }
}
