using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Logic;
using Griddle.Core.Xna.Math;
using System;

namespace Griddle.Example.Pong
{
    public class Ball : Actor
    {
        private Vector2 gameSize;

        private Vector2 velocity = Vector2.Zero;
        public Vector2 Velocity { get => velocity; }

        private Random random;

        public Ball(Sprite sprite, Vector2 gameSize) : base(sprite) {
            this.gameSize = gameSize;
            random = new Random(DateTime.Now.Millisecond);
        }

        public void Update()
        {
            if (velocity.IsZero()) {
                RandomizeVelocity();
            }

            CheckForWalls();
            Position = Position.Translate(velocity);
        }


        private void CheckForWalls()
        {
            var nextPosition = Position.Translate(velocity);

            // bounce off the walls
            if (nextPosition.X < 0 || nextPosition.X > gameSize.X-1)
            {
                velocity = new Vector2(-velocity.X, velocity.Y);
            }
            
        }

        private void RandomizeVelocity()
        {
            var nextX = random.Next(-1, 1);
            
            // y cannot ever be zero
            var nextY = random.Next(0,1);

            if (nextY == 0) {
                nextY = -1;
            }

            velocity = new Vector2(nextX, nextY);
        }

        public void BounceOffPaddle(int paddlePosition, int paddleSize) {

            var xVel = velocity.X;

            // if you hit the left or right size of the paddle, change x velocity
            if (paddlePosition == 0)
            {
                xVel = -1;
            }
            else if (paddlePosition == paddleSize) {
                xVel = 1;
            }
            
            
            velocity = new Vector2(xVel, -velocity.Y);

        }

        internal void Reset()
        {
            Position = new Vector2(8, 16);
            RandomizeVelocity();
        }
    }
}
