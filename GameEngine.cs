using System;

namespace TrulixConsole
{
    public class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2() : this(0, 0) { }
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GameObject
    {
        public Vector2 position { get; set; }
    }

    public class Point : GameObject
    {
        public Point() : this(0, 0) { }
        public Point(int x, int y)
        {
            position = new Vector2(x, y);
        }
    }

    public class Rectangle : GameObject
    {
        public int widht { get; set; }
        public int height { get; set; }

        public Rectangle() : this(0, 0, 0, 0) { }
        public Rectangle(int x,int y, int width,int height)
        {
            position = new Vector2(x, y);
            this.widht = width;
            this.height = height;
        }
    }

    public static class Physics
    {
        public static bool Collision(Point point1, Point point2) // проверка столкновений с точкой
        {
            return ((point1.position.x + 1) > point2.position.x) && (point1.position.x < (point2.position.x + 1) &&
                   (point1.position.y > point2.position.y) && (point1.position.y < point2.position.y));
        }

        public static bool Collision(Rectangle rect1,Rectangle rect2) // проверка на столкновение квадрата
        {
            return ((rect1.position.x + rect1.widht) > rect2.position.x) && (rect1.position.x < (rect2.position.x + rect2.widht)) &&
                   ((rect1.position.y + rect1.height) > rect2.position.y) && (rect1.position.y < (rect2.position.y + rect2.height));
        }
    }

    public static class Camera
    {
        public static void Render(Point point)
        {
            Console.SetCursorPosition(point.position.x, point.position.y);
            Console.Write("+");
        }

        public static void Render(Rectangle rect)
        {
            for (int x = 0; x < rect.widht; x++)
            {
                for (int y = 0; y < rect.height; y++)
                {
                    int xres = x + rect.position.x;
                    int yres = y + rect.position.y;

                    Console.SetCursorPosition(xres, yres);
                    Console.Write("@");
                }
            }
        }
    }
}
