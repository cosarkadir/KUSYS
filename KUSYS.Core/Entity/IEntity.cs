namespace KUSYS.Core.Entity
{
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Primary key of the entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
