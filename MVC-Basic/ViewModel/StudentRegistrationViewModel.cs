namespace MVC_Basic.ViewModel
{
    public class StudentRegistrationViewModel
    {
        // Personal Details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        // Contact Information
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Academic Details
        public string StudentId { get; set; }
        public string Course { get; set; }
    }


}
