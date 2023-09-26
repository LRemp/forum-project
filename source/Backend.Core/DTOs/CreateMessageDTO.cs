using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class CreateMessageDTO
    {
        public string Text { get; set; }
        public int Conversation {  get; set; }
    }
}
