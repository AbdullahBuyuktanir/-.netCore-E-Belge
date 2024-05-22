using Core.Utilities.ResultModel.Results;
using Core.Utilities.Results;

namespace Core.Utilities.ResultModel.Concrete;

public class DataResult<T> : Result
{
  public DataResult(bool isSuccess, string message, Error? error, T data) :
    base(isSuccess, message, error)
  {
    Data = data;
  }

  public DataResult(bool isSuccess, string message, Error? error) :
  base(isSuccess, message, error)
  {
  }

  public static DataResult<T> Success(string message, T data)
    => new(true, message, null, data);

  public static DataResult<T> Failure(string message, Error? error, T data)
    => new(false, message, error, data);


  public static new DataResult<T> Failure(string message, Error? error)
    => new(false, message, error);

  public T? Data { get; }
}
