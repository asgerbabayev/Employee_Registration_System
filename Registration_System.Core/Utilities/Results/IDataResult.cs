namespace Registration_System.Core.Utilities.Results;
public interface IDataResult<E>
{
    E Data { get; }
    bool Success { get; }
}