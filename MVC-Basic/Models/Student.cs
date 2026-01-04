using System.Reflection;

namespace MVC_Basic.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Course { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }

}
