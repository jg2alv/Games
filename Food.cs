using System;

namespace Snake
{
    class Food
    {
        public (int X, int Y) Coordinates { get; }
        public static Food DisplayedFood = null;

        public Food((int X, int Y) coordinates)
        {
            this.Coordinates = coordinates;
            Food.DisplayedFood = this;
        }

        public static bool IsThereFoodHere((int X, int Y) coordinates) => Food.DisplayedFood != null && Food.DisplayedFood.Coordinates.X == coordinates.X && Food.DisplayedFood.Coordinates.Y == coordinates.Y;

        public static void GenerateFood()
        {
            Random random = new Random();
            int x = random.Next(1, Console.WindowWidth + 1),
                y = random.Next(1, Console.WindowHeight + 1);

            Food f = new Food((x, y));
        }
    }
}
