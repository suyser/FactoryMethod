using FactoryMethod.FactoryMethod;


bool run = true;
Console.WriteLine("Возможные команды:");
   


while (run)
{
    Console.WriteLine(
        "1: Добавить\n" +
        "2: Вывести все\n" +
        "3: Вывести один\n" +
        "4: Выйти"
    );
    int command = int.Parse(Console.ReadLine());
    switch (command)
    {
        case 1:
            Console.WriteLine("Введите данные в формате <object>,<id>,<name>");
            string query = Console.ReadLine();
            InputHandler.CreateField(query);
            break;
        case 2:
            InputHandler.ReadFile();
            break;
        case 3:
            Console.WriteLine("Введите объект");
            string obj = Console.ReadLine();
            InputHandler.ReadFile(obj);
            break;
        case 4:
            run = false;
            break;
        default:
            Console.WriteLine("Такой команды не существует");
            break;

    }
}

