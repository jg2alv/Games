using System.Threading.Tasks;

namespace Snake
{
    class Node
    {
        public Directions Direction { get; set; }
        public (int X, int Y) Coordinates = (1, 0);
        public ((int X, int Y) Coordinates, Directions Direction) ChangeDirCoord { get; set; }

        public Node(Directions direction)
        {
            this.Direction = direction;
        }

        public async void Move()
        {
            await Task.Run(() => {
                while(true)
                {
                    if(this.Coordinates != this.ChangeDirCoord.Coordinates) continue;
                    this.Direction = this.ChangeDirCoord.Direction;
                    return;
                }
            });
        }

    }
}
