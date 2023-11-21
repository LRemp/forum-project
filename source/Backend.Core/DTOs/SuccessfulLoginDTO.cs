using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.DTOs
{
    public class SuccessfulLoginDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
    }
}
