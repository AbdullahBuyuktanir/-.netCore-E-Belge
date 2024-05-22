namespace Core.Utilities.ResultModel.Concrete;

public class PaginationDataResult<T> : DataResult<T>
{
  public PaginationDataResult(string message, T data,
    int pageNumber, int limit, int totalRecord) :
    base(true, message, null, data)
  {
    PageNumber = pageNumber;
    Limit = limit;
    TotalRecord = totalRecord;
    PageCount = Convert.ToInt32(Math.Ceiling((double)totalRecord / (double)limit));
  }

  public static PaginationDataResult<T> Success(string message, T data,
    int pageNumber, int limit, int totalRecord)
  => new(message, data, pageNumber, limit, totalRecord);

  public int PageNumber { get; set; }
  public int Limit { get; set; }
  public int TotalRecord { get; set; }
  public int PageCount { get; set; }
}
