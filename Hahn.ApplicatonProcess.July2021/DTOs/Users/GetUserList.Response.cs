using Hahn.ApplicatonProcess.July2021.Domain.Entities;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.July2021.Web.DTOs.Users
{
    public class UserInfoDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age {  get; set; }

        public string Address { get; set; }

        public string Email { get; set; }


    }
}
