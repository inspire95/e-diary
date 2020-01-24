export class BaseResponse<T> {
    data: T;
    isSuccess: boolean;
    errorMessage : string;
  }