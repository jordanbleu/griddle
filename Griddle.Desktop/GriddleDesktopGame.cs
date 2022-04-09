using Griddle.Core.Xna.Constants;
using Griddle.Core.Xna.Runtime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Griddle.Desktop
{
    /// <summary>
    /// Monogame implemenmtation of Griddle for Desktop (PC, Mac, Linux). 
    /// </summary>
    public class GriddleDesktopGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GriddleGame griddleGame;
        private Texture2D pixel;

        private DateTime lastUpdate;

        public GriddleDesktopGame(GriddleGame griddleGame)
        {            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.griddleGame = griddleGame;
        }

        protected override void Initialize()
        {

            if (griddleGame.Grid.Size.X > 640 || griddleGame.Grid.Size.Y > 480 || griddleGame.Grid.Size.X < 0 || griddleGame.Grid.Size.Y < 0) {
                throw new ArgumentException("Please specify a grid size between 0,0 and 640,480");
            }

            // Set the window size
            // You either get a portrait, landscape, or square sized window, based on the grid size.
            if (griddleGame.Grid.Size.X > griddleGame.Grid.Size.Y)
            {
                graphics.PreferredBackBufferWidth = 640;
                graphics.PreferredBackBufferHeight = 320;
            }
            else if (griddleGame.Grid.Size.X < griddleGame.Grid.Size.Y)
            {
                graphics.PreferredBackBufferWidth = 320;
                graphics.PreferredBackBufferHeight = 640;
            }
            else if (griddleGame.Grid.Size.X == griddleGame.Grid.Size.Y)
            {
                graphics.PreferredBackBufferWidth = 640;
                graphics.PreferredBackBufferHeight = 640;
            }

            graphics.ApplyChanges();

            griddleGame.GameInitialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Create a single pixel texture.
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            var data = new Color[] { Color.White};
            pixel.SetData(data);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (!griddleGame.IsRunning)
            {
                Exit();
            }

            // this block adds an artificial delay to the gameplay.  
            if ((DateTime.Now - lastUpdate).TotalMilliseconds >= griddleGame.Delay) { 
                griddleGame.Update();
                lastUpdate = DateTime.Now;
            }
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // render the griddle game in mono
            spriteBatch.Begin();


            for (var x = 0; x < griddleGame.Grid.Pixels.Length; x++)
            {
                if (griddleGame.Grid.Pixels[x] != null)
                {
                    for (var y = 0; y < griddleGame.Grid.Pixels[x].Length; y++)
                    {
                        var gPixel = griddleGame.Grid.Pixels[x][y];
                        
                        if (gPixel != null)
                        {
                            // todo:  this isn't right, there's still some janky sizes that cut off the pixels

                            // This is the exact screen resolution / the grid size.  It will likely not be a whole number.
                            var truePixelWidth = (float)graphics.PreferredBackBufferWidth / griddleGame.Grid.Size.X;
                            var truePixelHeight = (float)graphics.PreferredBackBufferHeight / griddleGame.Grid.Size.Y;

                            // chop off the decimal to get the best pixel size we can get
                            var pixelW = (int)MathF.Floor(truePixelWidth);
                            var pixelH = (int)MathF.Floor(truePixelHeight);

                            // See how many pixels we have left to distribute 
                            var remainingPixelsX = graphics.PreferredBackBufferWidth - (pixelW * griddleGame.Grid.Size.X);
                            var remainingPixelsY = graphics.PreferredBackBufferHeight - (pixelH * griddleGame.Grid.Size.Y);


                            // determine an offset.  This will be accurate to a single (actual) pixel (the best we can do)
                            var xOffset = (remainingPixelsX) > 0 ? (int)griddleGame.Grid.Size.X / remainingPixelsX : 0;
                            var yOffset = (remainingPixelsY) > 0 ? (int)griddleGame.Grid.Size.Y / remainingPixelsY : 0;

                            // calculate the x and y positions
                            var xPos = (x * pixelW) - (xOffset/2);
                            var yPos = (y * pixelH) - (yOffset/2);

                            // draw the pixel
                            spriteBatch.Draw(pixel, new Rectangle(xPos,yPos, pixelW + (xOffset/2), pixelH + (yOffset/2)), Color.White);

                        }

                    }
                }
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

