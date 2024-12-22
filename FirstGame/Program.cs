// Практическая работа по программированию №1
using System;

namespace FirstGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру \"Сбеги из комнаты\"!");

            // Запрос имени игрока
            Console.Write("Введите имя вашего персонажа: ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Привет, {playerName}! Давайте начнем ваш квест.\n");

            // Инициализация переменных
            bool hasArtifact1 = false;
            bool hasArtifact2 = false;
            bool hasArtifact3 = false;
            bool statueActivated = false;
            bool hasKey = false;
            bool hasLockpick = false;
            bool doorOpened = false;

            int ventilationAttempts = 0;

            while (!doorOpened)
            {
                // Главное меню действий
                Console.WriteLine("Вы находитесь в комнате. Вы можете:");
                Console.WriteLine("1. Открыть дверь");
                Console.WriteLine("2. Заглянуть под кровать");
                Console.WriteLine("3. Открыть ящик в углу комнаты");
                Console.WriteLine("4. Открыть вентиляцию");
                Console.WriteLine("5. Взглянуть на тумбочку");
                Console.WriteLine("6. Взглянуть на статую рядом с дверью");
                Console.Write("Введите номер действия: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, вы используете отмычку и открываете дверь. Вы успешно сбежали!");
                            doorOpened = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, дверь заперта. Нужно найти способ её открыть.");
                        }
                        break;

                    case "2":
                        if (!hasArtifact1)
                        {
                            Console.WriteLine($"{playerName}, вы нашли первый артефакт под кроватью.");
                            hasArtifact1 = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, под кроватью больше ничего нет.");
                        }
                        break;

                    case "3":
                        if (hasKey)
                        {
                            if (!hasLockpick)
                            {
                                Console.WriteLine($"{playerName}, вы открыли ящик и нашли отмычку.");
                                hasLockpick = true;
                            }
                            else
                            {
                                Console.WriteLine($"{playerName}, ящик уже пуст.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик заперт. Нужен ключ.");
                        }
                        break;

                    case "4":
                        ventilationAttempts++;
                        if (ventilationAttempts == 3)
                        {
                            if (!hasArtifact2)
                            {
                                Console.WriteLine($"{playerName}, вы открыли вентиляцию и нашли второй артефакт.");
                                hasArtifact2 = true;
                            }
                            else
                            {
                                Console.WriteLine($"{playerName}, в вентиляции больше ничего нет.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, вы пытаетесь открыть вентиляцию. Она не поддается.");
                        }
                        break;

                    case "5":
                        if (!hasArtifact3)
                        {
                            Console.WriteLine($"{playerName}, вы нашли третий артефакт на тумбочке.");
                            hasArtifact3 = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, на тумбочке больше ничего нет.");
                        }
                        break;

                    case "6":
                        if (hasArtifact1 && hasArtifact2 && hasArtifact3)
                        {
                            if (!statueActivated)
                            {
                                Console.WriteLine($"{playerName}, вы активировали статую, и она дала вам ключ от ящика.");
                                statueActivated = true;
                                hasKey = true;
                            }
                            else
                            {
                                Console.WriteLine($"{playerName}, статуя уже активирована.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, чтобы активировать статую, нужны все три артефакта.");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Спасибо за игру!");
        }
    }
}
