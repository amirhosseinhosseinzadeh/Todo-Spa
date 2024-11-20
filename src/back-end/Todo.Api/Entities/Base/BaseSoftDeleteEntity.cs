namespace Todo.Api.Entities.Base;

public class BaseSoftDeleteEntity : BaseEntity, ISoftDelete
{
    public bool IsDeleted  { get; set; }
}

