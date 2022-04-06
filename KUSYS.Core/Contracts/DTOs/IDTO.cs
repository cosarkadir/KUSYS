namespace KUSYS.Core.Contracts.DTOs
{
    public interface IDTO<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}