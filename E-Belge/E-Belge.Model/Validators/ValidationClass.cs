﻿using Core.Utilities.ResultModel.Results;
using FluentValidation;

namespace E_Belge.Model.Validators;

public class ValidationClass
{
  public static Error Validate(IValidator validator, object entity)
  {
    var context = new ValidationContext<object>(entity);
    var result = validator.Validate(context);

    if (!result.IsValid)
      return new Error(result.Errors[0].ErrorCode, result.Errors[0].ErrorMessage);

    return Error.None;
  }
}
