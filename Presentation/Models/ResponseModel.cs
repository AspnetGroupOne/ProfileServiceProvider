namespace Presentation.Models;
public class ResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public string? ErrorCode { get; set; }
}

public class ResponseModel<T> : ResponseModel
{
    public T Object { get; set; } = default(T)!;
}
