using Models;

namespace Interface;

public interface IHandler
{
    void HandleRequest(Data data);
    void SetNextHandler(IHandler nextHandler);
}