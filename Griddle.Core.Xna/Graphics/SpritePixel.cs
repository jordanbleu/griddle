using Griddle.Core.Xna.Math;

namespace Griddle.Core.Xna.Graphics
{
    /// <summary>
    /// A pixel that exists on a sprite
    /// </summary>
    public class SpritePixel
    {
        public SpritePixel() {}

        public SpritePixel(Vector2 position, Pixel pixel)
        {
            Position = position;
            Pixel = pixel;
        }

        /// <summary>
        /// The position of this pixel within the sprite
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The pixel within this sprite
        /// </summary>
        public Pixel Pixel { get; set; }

    }
}
