using Griddle.Core.Xna.Math;
using System.Collections.Generic;

namespace Griddle.Core.Xna.Graphics
{
    public class Sprite
    {

        /// <summary>
        /// The position of the Sprite
        /// </summary>
        public Vector2 Position { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// The anchor / handle position
        /// </summary>
        public Vector2 Anchor { get; set; } = new Vector2(0, 0);

        /// <summary>
        /// The layer / z-axis for the sprites.  
        /// </summary>
        public int Layer { get; set; } = 0;

        /// <summary>
        /// The actual pixels of the sprite
        /// </summary>
        public List<SpritePixel> Pixels { get; set; }


    }
}
