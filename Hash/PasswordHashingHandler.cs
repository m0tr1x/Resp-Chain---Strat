// Конкретный обработчик для хеширования пароля с использованием стратегии

using Interface;
using Models;

public class PasswordHashingHandler : IHandler
{
    private IHandler _nextHandler;
    private IHashStrategy _hashStrategy;

    public PasswordHashingHandler(IHashStrategy hashStrategy)
    {
        _hashStrategy = hashStrategy;
    }

    public void SetNextHandler(IHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public void HandleRequest(Data data)
    {
        Console.WriteLine("Hashing password...");
        // Хеширование пароля с использованием стратегии
        string hashedPassword = _hashStrategy.GetHash(data.Password);
        Console.WriteLine($"Password hashed: {hashedPassword}");

        // Если пароль был успешно хеширован, передаем запрос следующему обработчику
        _nextHandler?.HandleRequest(data);
    }
}