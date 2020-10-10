using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Snake
    {
        private (int X, int Y) _coordinates = (Console.WindowWidth / 2, Console.WindowHeight / 2);
        private List<Node> _body = new List<Node>();
        public static int Unit = 1 + (2 - 1) * (Console.WindowHeight - 1) / (Console.WindowWidth - 1);
        public Directions Direction { get; private set; } = Directions.Right;
        public int Size { get => this._body.Count; }
        public int FrameRate = 500;

        public Snake()
        {
            this.Grow();
            this.Grow();
            this.Grow();
        }

        public void Move(Directions direction, bool isDefaultForce = false)
        {
            // If the snake's head is touching any borders
            // OR
            // its own tale
            if (this._coordinates.X == Console.WindowWidth || this._coordinates.X == 0 || this._coordinates.Y == Console.WindowHeight || this._coordinates.Y == 0 || Node.IsThereANodeHere(this._coordinates))
                Program.Quit("YOU LOST!");

            // If the player is trying to go to the opposite direction (right - left, up - down)
            // OR
            // If the current direction is the same as the new direction
            // AND
            // This movement isn't the default force
            if ((int)this.Direction + (int)direction == 0 || this.Direction == direction && !isDefaultForce) return;

            // If the new direction is UP, remove one unit on Y
            // If it's DOWN, add one unit on Y
            // If it's LEFT, remove one unit on X
            // If it's RIGHT, add one unit on X
            if (direction == Directions.Up)
                this._coordinates.Y -= Snake.Unit;
            else if (direction == Directions.Down)
                this._coordinates.Y += Snake.Unit;
            else if (direction == Directions.Left)
                this._coordinates.X -= Snake.Unit;
            else
                this._coordinates.X += Snake.Unit;

            // Setting the new direction;
            // For every node, add the new direction to the direction-coordinate change list
            // (if it's not the same direction the node is going to) and move the nodes
            this.Direction = direction;
            this._body.ForEach(n =>
            {
                if (n.Direction != direction)
                    n.Change.Add((this._coordinates, this.Direction));

                n.Move();
            });

            this.EatFood();
        }

        public void EatFood()
        {
            // If there's no food here, quit.
            // If there's, eat it and increase the tale
            if (!Food.IsThereFoodHere(this._coordinates)) return;

            Food.DisplayedFood = null;
            this.Grow();
        }

        public void Draw()
        {
            // Drawing every node on screen
            this._body.ForEach(n =>
            {
                Console.SetCursorPosition(n.Coordinates.X, n.Coordinates.Y);
                Console.Write(n.Char);
            });
        }

        public void Grow()
        {
            // Initializing
            //      * coordinates of the new grown node
            //      * base coordinates where the new ones will be calculated upon
            //      * base direction (direction that the new born node should follow)
            (int X, int Y) coordinates;
            (int X, int Y) baseCoordinates = this._coordinates;
            Directions baseDirection = this.Direction;

            // If there's more than one node, set all of the previous vars to its own
            if (this._body.Count > 0)
            {
                baseCoordinates = this._body.Last().Coordinates;
                baseDirection = this._body.Last().Direction;
            }

            // Calculating X and Y position of new grown node on the grid
            if (baseDirection == Directions.Up)
                coordinates = (baseCoordinates.X, baseCoordinates.Y - Snake.Unit);
            else if (baseDirection == Directions.Down)
                coordinates = (baseCoordinates.X, baseCoordinates.Y + Snake.Unit);
            else if (baseDirection == Directions.Right)
                coordinates = (baseCoordinates.X - Snake.Unit, baseCoordinates.Y);
            else
                coordinates = (baseCoordinates.X + Snake.Unit, baseCoordinates.Y);

            // Creating the new node and adding it to the node list
            Node n = new Node(this.Direction, coordinates);
            this._body.Add(n);

            // 50% chance of making the game go faster
            if (new Random().Next(1, 3) % 2 == 0)
                this.FrameRate = (int)(this.FrameRate * 0.9);

            // Set the cursor to the position of the new grown node
            Console.SetCursorPosition(baseCoordinates.X, baseCoordinates.Y);
        }
    }
}
