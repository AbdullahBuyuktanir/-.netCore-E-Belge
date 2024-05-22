namespace Core.Utilities.ResultModel.Concrete;

public class PaginationQuery
{
  const int maxPageSize = 1000;
  private int pageSize = maxPageSize;

  public int PageNumber { get; set; } = 1;

  public int Limit
  {
    get
    {
      return pageSize;
    }
    set
    {
      pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
  }
}