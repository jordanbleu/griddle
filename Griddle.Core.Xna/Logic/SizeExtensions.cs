using Griddle.Core.Xna.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Griddle.Core.Xna.Logic
{
    public static class SizeExtensions
    {

        /// <summary>
        /// Calculates the overall width of the sprite
        /// </summary>
        public static int Width(this IDrawable drawable)
        {
            if (drawable.Pixels != null && drawable.Pixels.Count > 0)
            {
                return drawable.Pixels.Select(p => p.Position.X).OrderByDescending(x => x).FirstOrDefault();
            }
            return 0;
        }

        /// <summary>
        /// Calculates the overall height of the sprite
        /// </summary>
        public static int Height(this IDrawable drawable)
        { 
            if (drawable.Pixels != null && drawable.Pixels.Count > 0)
            {
                return drawable.Pixels.Select(p => p.Position.Y).OrderByDescending(y => y).FirstOrDefault();
            }
            return 0;
        }


    }
}
