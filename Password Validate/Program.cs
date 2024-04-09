using Hash;
using Interface;
using Models;
using Validation;

namespace Password_Validate;

class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр стратегии хеширования
        IHashStrategy hashStrategy = new SHA512HashStrategy();
        // Создание обработчиков
        IHandler passwordValidationHandler = new PasswordValidationHandler();
        IHandler passwordHashingHandler = new PasswordHashingHandler(hashStrategy); 

        // Установка цепочки обработчиков
        passwordValidationHandler.SetNextHandler(passwordHashingHandler);

        // Создание и отправка запроса на валидацию пароля
        Console.WriteLine(" Enter password");
        Data data = new Data { Password = Console.ReadLine() };
        passwordValidationHandler.HandleRequest(data);
    }
}