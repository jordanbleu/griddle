namespace Griddle.Core.Xna.Math
{
    public struct Vector2
    {
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }


        /// <summary>
        /// Returns a new Vector2 translated by the provided amount
        /// </summary>
        public Vector2 Translate(Vector2 translation) => Translate(translation.X, translation.Y);

        /// <summary>
        /// Returns a new Vector2 translated by the provided amount
        /// </summary>
        public Vector2 Translate(int xMovement, int yMovement) { 
            return new Vector2(X + xMovement, Y + yMovement);   
        }

        /// <summary>
        /// returns true if both X and Y are zero
        /// </summary>
        public bool IsZero() => X == 0 && Y == 0;

        /// <summary>
        /// Returns Vector2 of 0,0
        /// </summary>
        public static Vector2 Zero = new Vector2(0, 0); 

    }
}
