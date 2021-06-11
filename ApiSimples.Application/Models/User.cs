using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSimples.Application.Models
{
    public class User
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
        }

    }
}
