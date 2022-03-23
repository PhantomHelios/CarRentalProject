using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:Core/Entities/DTOs/UserForRegisterDto.cs
namespace Core.Entities.DTOs
=======
namespace Core.Entities.Concrete
>>>>>>> 2c4525286e7ca7912dc3f38ccdd0829261c7cee9:Core/Entities/Concrete/User.cs
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
