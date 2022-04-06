namespace KUSYS.Core.Contracts.DTOs
{
    public class StudentDTO: DTOBase<int>
    {
        public string CourseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public CourseDTO Course { get; set; }
    }
}
