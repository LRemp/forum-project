using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class MessageDTO
    {
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public User Author { get; set; }
        public ConversationDTO Conversation { get; set; }
    }
}
