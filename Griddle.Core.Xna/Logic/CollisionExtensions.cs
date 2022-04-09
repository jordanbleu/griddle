using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Math;

namespace Griddle.Core.Xna.Logic
{
    public static class CollisionExtensions
    {


        /// <summary>
        /// Cheap / quick collision detection.  This will estimate if two sprites are colliding by creating a basic bounding box on the fly.
        /// </summary>
        public static bool IsOverlapping(this IDrawable me, IDrawable other) => IsOverlapping(me, me.Position, other);

        /// <summary>
        /// Cheap / quick collision detection.  This will estimate if two sprites are colliding by creating a basic bounding box on the fly.
        /// </summary>
        public static bool IsOverlapping(this IDrawable me, Vector2 position, IDrawable other) {
            var left = position.X;
            var top = position.Y;
            var right = left + me.Width();
            var bottom = top + me.Height();

            var otherLeft = other.Position.X;
            var otherTop = other.Position.Y;
            var otherRight = other.Position.X + other.Width();
            var otherBottom = other.Position.Y + other.Height();

            if (right < otherLeft || left > otherRight || bottom < otherTop || top > otherBottom)
            {
                return false;
            }

            return true;


        }
        


    }
}
