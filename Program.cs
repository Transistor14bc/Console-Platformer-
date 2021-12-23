using System;
using TrulixConsole;
using System.Threading;

namespace ReliableJump
{
    internal class Program
    {
        private static Rectangle player = new Rectangle(0,0,5,5);
        private static Rectangle rect = new Rectangle(0,10,15,5);
        private static Rectangle rect1 = new Rectangle(17, 8, 15, 5);
        private static Rectangle rect2 = new Rectangle(34, 14, 15, 5);
        private static Rectangle rect3 = new Rectangle(55, 14, 15, 5);
        private static bool run; // переменная запуска
        private static int gravitySpeed; // переменная скорости гравитацыи
        private static int speed; // переменая скорости передвижения

        static void Main(string[] args)
        {
            run = true;;
            speed = 1;
            gravitySpeed = 1;

            Update();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("YOU WIN");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("YOU WIN");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("YOU WIN");

            Console.ReadLine();
        }

        public static void Update()
        {
            while (run)
            {
                if(Console.KeyAvailable == true) // если тажата какаято кнопка
                {
                    ConsoleKey key = Console.ReadKey().Key; // считываем нажатие кнопки

                    if(key == ConsoleKey.Spacebar) // если нажат пробел
                    {
                        gravitySpeed = -5;
                    }
                    if(key == ConsoleKey.A) 
                    {
                        player.position.x -= speed;
                    }
                    if (key == ConsoleKey.D)
                    {
                        player.position.x += speed;
                    }
                }
                else // 
                {
                    player.position.y += gravitySpeed; // добавляем силу гравитацыи
                    if (Physics.Collision(rect, player)) {gravitySpeed = 0; }
                    else if (Physics.Collision(rect1, player)) { gravitySpeed = 0; }
                    else if (Physics.Collision(rect2, player)) { gravitySpeed = 0; }
                    else if (Physics.Collision(rect3, player)) { run = false; } // если мы сталкиваемся с 3 квадратом, то цыкл завершаетса
                    else { gravitySpeed = 1;}
                }

                Thread.Sleep(3);
                
                Console.Clear();

                Camera.Render(rect);
                Camera.Render(rect1);
                Camera.Render(rect2);
                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем зелёный цвет консоли
                Camera.Render(rect3);
                Console.ForegroundColor = ConsoleColor.White; // аозращаем белы

                Console.ForegroundColor = ConsoleColor.Red; // устанавлиаем красный
                Camera.Render(player);
                Console.ForegroundColor = ConsoleColor.White; // возвращаем белый
            }
        }
    }
}
