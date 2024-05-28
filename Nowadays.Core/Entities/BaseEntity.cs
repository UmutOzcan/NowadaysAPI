
namespace Nowadays.Core.Entities;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
