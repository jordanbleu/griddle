using Griddle.Core.Xna.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Griddle.Core.Xna.Graphics
{
    /// <summary>
    /// Interface for objects that are drawable to the grid
    /// </summary>
    public interface IDrawable
    {
        int Layer { get;}

        List<SpritePixel> Pixels { get; }

        Vector2 Position { get; }
    }
}
