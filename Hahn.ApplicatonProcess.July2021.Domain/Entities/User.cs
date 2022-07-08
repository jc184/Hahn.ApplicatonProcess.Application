using Hahn.ApplicatonProcess.July2021.Domain.Base;
using System.Collections.Generic;

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public ICollection<Asset> Assets { get; set; }

    }
}
