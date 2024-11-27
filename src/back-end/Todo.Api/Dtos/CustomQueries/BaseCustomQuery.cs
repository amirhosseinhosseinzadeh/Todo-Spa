namespace Todo.Api.Dtos.Customqueires;

public class BaseCustomQuery<TQuerModel> : BaseCustomQuery
{  }

public class BaseCustomQuery
{
    public int Size { get; set; }
    public int Skip { get; set; }
}
