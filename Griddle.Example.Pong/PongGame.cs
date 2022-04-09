using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Input;
using Griddle.Core.Xna.Logic;
using Griddle.Core.Xna.Math;
using Griddle.Core.Xna.Runtime;
using System.Collections.Generic;

namespace Griddle.Example.Pong
{
    public class PongGame : GriddleGame
    {
        private Ball ball;
        private Player player1;
        private Player player2;
        private Vector2 gameSize;

        private int score1;
        private int score2;

        public PongGame(Vector2 size, IInputHandler inputHandler) : base(size, inputHandler) {
            this.gameSize = size;
        }

        public override void GameInitialize()
        {
            // define the sprites
            var player2Sprite = new Sprite()
            {
                Position = new Vector2(8, 0),
                Pixels = new List<SpritePixel>() {
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                    new SpritePixel(new Vector2(1,0), new Pixel()),
                    new SpritePixel(new Vector2(2,0), new Pixel()),
                    new SpritePixel(new Vector2(3,0), new Pixel()),
                    new SpritePixel(new Vector2(4,0), new Pixel()),
                }
            };

            var player1Sprite = new Sprite()
            {
                Position = new Vector2(8, 31),
                Pixels = new List<SpritePixel>() {
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                    new SpritePixel(new Vector2(1,0), new Pixel()),
                    new SpritePixel(new Vector2(2,0), new Pixel()),
                    new SpritePixel(new Vector2(3,0), new Pixel()),
                    new SpritePixel(new Vector2(4,0), new Pixel()),
                }
            };

            var ballSprite = new Sprite()
            {
                Position = new Vector2(8, 16),
                Pixels = new List<SpritePixel>() {
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                }
            };

            // this demonstrates the use of 'actors' rather
            // than sprites for a more object oriented approach 

            ball = new Ball(ballSprite, gameSize);
            player1 = new HumanPlayer(player1Sprite, gameSize, ball);
            
            // Uncomment for AI player
            player2 = new ComputerPlayer(player2Sprite, gameSize, ball); 
            // Uncomment for human player using WASD keys
            //player2 = new SecondHumanPlayer(player2Sprite, gameSize, ball);

            Grid.Sprites.Add(player1);
            Grid.Sprites.Add(player2);
            Grid.Sprites.Add(ball);
        }

        protected override void GameUpdate()
        {
            player1.Update(Input);
            player2.Update(Input);
            ball.Update();

            // if ball is colliding with paddle 1, reverse y velocity

            var nextPosition = new Vector2(ball.Position.X + ball.Velocity.X, ball.Position.Y + ball.Velocity.Y);   

            if (ball.IsOverlapping(nextPosition,player1))
            {
                var paddlePosition = ball.Position.X - player1.Position.X;
                ball.BounceOffPaddle(paddlePosition, player1.Width());
            }
            else if (ball.IsOverlapping(nextPosition,player2)) {
                var paddlePosition = ball.Position.X - player2.Position.X;
                ball.BounceOffPaddle(paddlePosition, player2.Width());
            }

            // check for scores
            if (ball.Position.Y > Grid.Size.Y)
            {
                score1++;
                ball.Reset();
            }
            else if (ball.Position.Y < 0) {
                score2++;
                ball.Reset();
            }

            // Show scores in the title bar
            GameTitle = $"{score1} -- {score2}";

        }

    }
}
