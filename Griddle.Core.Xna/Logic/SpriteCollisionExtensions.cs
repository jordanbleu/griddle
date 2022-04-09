using Griddle.Core.Xna.Graphics;

namespace Griddle.Core.Xna.Logic
{
    public class CollisionExtensions
    {

                
        /// <summary>
        /// Cheap / quick collision detection.  This will estimate if two sprites are colliding by creating a basic bounding box on the fly.
        /// </summary>
        public static bool IsOverlapping(this IDrawable me, IDrawable other) {

            var left = me.Position.X + me.Anchor.X;
            var top = me.Position.Y + me.Anchor.Y; 
            var right = left + me.S
            
        
            return false;
        }

    }
}
