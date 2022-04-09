using Griddle.Core.Xna.Math;
using System.Collections.Generic;
using System.Linq;

namespace Griddle.Core.Xna.Graphics
{
    /// <summary>
    /// The grid is the heart of Gridle.  It is responsible for maintaining an abstraction of the graphics.
    /// </summary>
    public class Grid
    {
        private Vector2 size;

        public Grid(Vector2 gridSize)
        {
            this.size = gridSize;
        }

        public Vector2 Size { get => size; }

        // The actual pixels on the grid
        public Pixel[][] Pixels { get; private set; }

        // Sprites active in the grid.  Not necessarily basic sprites, could be actors, etc
        public List<IDrawable> Sprites { get; set; } = new List<IDrawable>();

        /// <summary>
        /// Update the grid with the current state of the sprites
        /// </summary>
        public void Refresh()
        {
            ClearGrid();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            foreach (var sprite in Sprites.OrderBy(spr => spr.Layer))
            {
                foreach (var pixel in sprite.Pixels)
                {
                    var px = pixel.Position.X + sprite.Position.X;
                    var py = pixel.Position.Y + sprite.Position.Y;

                    if (InBounds(px, py))
                    {

                        // Initialize the array as needed
                        if (Pixels[px] == null)
                        {
                            Pixels[px] = new Pixel[size.Y];
                        }

                        Pixels[px][py] = new Pixel();
                    }
                }
            }
        }

        private void ClearGrid()
        {
            Pixels = new Pixel[size.X][];
        }

        private bool InBounds(int x, int y) =>
            x > -1 &&
            x < size.X &&
            y > -1 &&
            y < size.Y;

    }
}
