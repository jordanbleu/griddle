using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Math;
using Griddle.Core.Xna.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Griddle.Example.Pong
{
    public class PongGame : GriddleGame
    {
        private Sprite player1;
        private Sprite player2;
        private Sprite ball;

        public PongGame(Vector2 size) : base(size) { }
        

        public override void GameInitialize()
        {
            player2 = new Sprite()
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

            player1 = new Sprite()
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

            ball = new Sprite()
            {
                Position = new Vector2(8, 16),
                Pixels = new List<SpritePixel>() {
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                }
            };

            Grid.Sprites.Add(player1);
            Grid.Sprites.Add(player2);
            Grid.Sprites.Add(ball);
        }

        protected override void GameUpdate()
        {

            
        }
    }
}
