using Core.Utilities.ResultModel.Results;
namespace Core.Utilities.Results;

public class Result
{
  public Result(bool isSuccess, string message, Error? error)
  {
    //if (isSuccess && error is not null ||
    //    !isSuccess && error is null)
    //{
    //  throw new ArgumentException("Geçersiz hata ataması.", nameof(error));
    //}

    IsSuccess = isSuccess;
    Message = message;
    Error = error;
  }

  public bool IsSuccess { get; }
  public string Message { get; }
  public Error? Error { get; }

  public static Result Success(string message) => new(true, message, null);

  public static Result Failure(string message, Error error)
    => new(false, message, error);
}
