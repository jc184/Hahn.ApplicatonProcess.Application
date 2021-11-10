using Hahn.ApplicatonProcess.July2021.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public User()
        {
        }

        public User(string firstName, string lastName, string address, int age, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Age = age;
            Email = email;
        }

        //public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public ICollection<Asset> Assets { get; set; }


    }
}
