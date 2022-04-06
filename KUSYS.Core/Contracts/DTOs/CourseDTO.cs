namespace KUSYS.Core.Contracts.DTOs
{
    public class CourseDTO : DTOBase<string>
    {
        public string CourseName { get; set; }
        public List<StudentDTO> Students { get; set; }
    }
}