using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class CreateConversationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Channel { get; set; }
    }
}
