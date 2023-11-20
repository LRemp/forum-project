using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class UpdateUserDTO
    {
        public long Id;
        public string? Username;
        public string Password;
    }
}
