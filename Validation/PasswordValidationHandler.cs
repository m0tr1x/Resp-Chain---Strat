using Interface;
using Models;

namespace Validation;

public class PasswordValidationHandler : IHandler
{
    
    private IHandler _nextHandler;
    
    /// <summary>
    /// Обработка запроса
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void HandleRequest(Data data)
    {
        Console.WriteLine("Validating password...");
        // Проверка пароля на безопасность
        if (!IsPasswordSecure(data.Password))
        {
            Console.WriteLine("Password is not secure. Please choose a stronger password.");
            return;
        }
        Console.WriteLine("Password is secure.");

        // Если пароль прошел валидацию, передаем запрос следующему обработчику
        _nextHandler?.HandleRequest(data);
    }
    
    
    /// <summary>
    /// Метод для базовой проверки пароля на безопасность
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool IsPasswordSecure(string password)
    {
        // Пример условий безопасного пароля
        return password.Length >= 8 && password.Any(char.IsLetter) && password.Any(char.IsDigit);
    }

    
    /// <summary>
    /// Метод для фиксации ссылки на следующий обработчик
    /// </summary>
    /// <param name="nextHandler"></param>
    public void SetNextHandler(IHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }
}