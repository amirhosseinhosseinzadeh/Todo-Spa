namespace Todo.Api.Entities;

public class Application
{
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTime AnounceDate { get; set; }

    public string Title { get; set; }

    public bool IsActive { get; set; }
}
