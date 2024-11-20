namespace Todo.Api.Entities.Base;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}
