using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Application.DTO
{
    public class JwtResponseDTO
    {
        public JwtResponseDTO()
        {
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        

    }
}
