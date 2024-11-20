using Todo.Api.Entities.Base;

namespace Todo.Api.Entities;

public class Application : BaseSoftDeleteEntity
{
    public string Description { get; set; }

    public DateTime AnounceDate { get; set; }

    public string Title { get; set; }

    public bool IsActive { get; set; }
}
