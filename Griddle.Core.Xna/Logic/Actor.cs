using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace Griddle.Core.Xna.Logic
{
    /// <summary>
    /// An 'actor' is a decorator object that wraps sprite functionality for encapsulated logic.
    /// </summary>
    public abstract class Actor : IDrawable
    {
        private Sprite sprite;
        public Sprite Sprite { get => sprite; set => sprite = value; }

        public Actor(Sprite sprite) {
            this.sprite = sprite;
        }

        public int Layer => Sprite.Layer;

        public List<SpritePixel> Pixels => Sprite.Pixels;

        public Vector2 Position
        {
            get { return Sprite.Position; }
            set { Sprite.Position = value; }
        }
        

        public Vector2 Anchor => Sprite.Anchor;

    }
}
