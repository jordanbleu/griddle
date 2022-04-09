using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Input;
using Griddle.Core.Xna.Logic;
using Griddle.Core.Xna.Math;

namespace Griddle.Example.Pong
{
    /// <summary>
    /// Base logic for either human or AI player
    /// </summary>
    public abstract class Player : Actor
    {
        private Vector2 gameSize;
        protected Vector2 GameSize { get => gameSize; }

        private Ball ball;
        protected Ball Ball { get => ball; }

        protected Player(Sprite sprite, Vector2 gridSize, Ball ball) : base(sprite) {
            this.gameSize = gridSize;
            this.ball = ball;
        }

        public abstract void Update(IInputHandler input);

    }
}
