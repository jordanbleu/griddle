using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Math;
using Griddle.Core.Xna.Runtime;
using System.Collections.Generic;

namespace Griddle.Example.HelloWorld
{
    public class HelloWorldGame : GriddleGame
    {
        public HelloWorldGame(Vector2 size) : base(size) { }

        private Sprite sprite;
        private Sprite corners;

        public override void GameInitialize()
        {
            // use this to test the display logic
            corners = new Sprite()
            {
                Position = new Vector2(0, 0),
                Pixels = new List<SpritePixel>() {
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                    new SpritePixel(new Vector2(Grid.Size.X-1,0), new Pixel()),
                    new SpritePixel(new Vector2(Grid.Size.X-1,Grid.Size.Y-1), new Pixel()),
                    new SpritePixel(new Vector2(0,Grid.Size.Y-1), new Pixel()),
                }
            };

            sprite = new Sprite()
            {
                Position = new Vector2(0, 0),
                Pixels = new List<SpritePixel>()
                {
                    // H
                    new SpritePixel(new Vector2(0,0), new Pixel()),
                    new SpritePixel(new Vector2(0,1), new Pixel()),
                    new SpritePixel(new Vector2(0,2), new Pixel()),
                    new SpritePixel(new Vector2(0,3), new Pixel()),
                    new SpritePixel(new Vector2(0,4), new Pixel()),
                    new SpritePixel(new Vector2(0,5), new Pixel()),

                    new SpritePixel(new Vector2(1,2), new Pixel()),

                    new SpritePixel(new Vector2(2,0), new Pixel()),
                    new SpritePixel(new Vector2(2,1), new Pixel()),
                    new SpritePixel(new Vector2(2,2), new Pixel()),
                    new SpritePixel(new Vector2(2,3), new Pixel()),
                    new SpritePixel(new Vector2(2,4), new Pixel()),
                    new SpritePixel(new Vector2(2,5), new Pixel()),

                    // E
                    new SpritePixel(new Vector2(4,0), new Pixel()),
                    new SpritePixel(new Vector2(4,1), new Pixel()),
                    new SpritePixel(new Vector2(4,2), new Pixel()),
                    new SpritePixel(new Vector2(4,3), new Pixel()),
                    new SpritePixel(new Vector2(4,4), new Pixel()),
                    new SpritePixel(new Vector2(4,5), new Pixel()),

                    new SpritePixel(new Vector2(5,0), new Pixel()),
                    new SpritePixel(new Vector2(6,0), new Pixel()),

                    new SpritePixel(new Vector2(5,2), new Pixel()),

                    new SpritePixel(new Vector2(5,5), new Pixel()),
                    new SpritePixel(new Vector2(6,5), new Pixel()),

                    // L
                    new SpritePixel(new Vector2(8,0), new Pixel()),
                    new SpritePixel(new Vector2(8,1), new Pixel()),
                    new SpritePixel(new Vector2(8,2), new Pixel()),
                    new SpritePixel(new Vector2(8,3), new Pixel()),
                    new SpritePixel(new Vector2(8,4), new Pixel()),
                    new SpritePixel(new Vector2(8,5), new Pixel()),

                    new SpritePixel(new Vector2(9,5), new Pixel()),
                    new SpritePixel(new Vector2(10,5), new Pixel()),

                    // L
                    new SpritePixel(new Vector2(12,0), new Pixel()),
                    new SpritePixel(new Vector2(12,1), new Pixel()),
                    new SpritePixel(new Vector2(12,2), new Pixel()),
                    new SpritePixel(new Vector2(12,3), new Pixel()),
                    new SpritePixel(new Vector2(12,4), new Pixel()),
                    new SpritePixel(new Vector2(12,5), new Pixel()),

                    new SpritePixel(new Vector2(13,5), new Pixel()),
                    new SpritePixel(new Vector2(14,5), new Pixel()),

                    // O
                    new SpritePixel(new Vector2(16,0), new Pixel()),
                    new SpritePixel(new Vector2(16,1), new Pixel()),
                    new SpritePixel(new Vector2(16,2), new Pixel()),
                    new SpritePixel(new Vector2(16,3), new Pixel()),
                    new SpritePixel(new Vector2(16,4), new Pixel()),
                    new SpritePixel(new Vector2(16,5), new Pixel()),

                    new SpritePixel(new Vector2(17,0), new Pixel()),
                    new SpritePixel(new Vector2(17,5), new Pixel()),

                    new SpritePixel(new Vector2(18,0), new Pixel()),
                    new SpritePixel(new Vector2(18,1), new Pixel()),
                    new SpritePixel(new Vector2(18,2), new Pixel()),
                    new SpritePixel(new Vector2(18,3), new Pixel()),
                    new SpritePixel(new Vector2(18,4), new Pixel()),
                    new SpritePixel(new Vector2(18,5), new Pixel()),
                }
            };

            Grid.Sprites.Add(sprite);
            Grid.Sprites.Add(corners);

        }

        protected override void GameUpdate()
        {
            // translate to the left, until we reach the end then wrap back to the right size
            sprite.Position = new Vector2(sprite.Position.X - 1, sprite.Position.Y);

            if (sprite.Position.X < -Grid.Size.X)
            {
                sprite.Position = new Vector2(Grid.Size.X, sprite.Position.Y);
            }


        }
    }
}
