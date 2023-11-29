using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Entities
{
    public class ChannelRequest
    {
        public string Id { get; set; }
        public int FkUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
