using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.DTO.Request
{
    public class UserRegistrationRequest
    {
        public string Name { get; set; }

        public string EmailId { get; set; }

        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
