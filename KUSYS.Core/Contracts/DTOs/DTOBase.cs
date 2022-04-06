namespace KUSYS.Core.Contracts.DTOs
{
    public abstract class DTOBase<TPrimaryKey> : IDTO<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
