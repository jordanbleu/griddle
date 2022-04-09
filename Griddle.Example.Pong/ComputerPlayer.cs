using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Input;
using Griddle.Core.Xna.Logic;
using Griddle.Core.Xna.Math;

namespace Griddle.Example.Pong
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(Sprite sprite, Vector2 gridSize, Ball ball) : base(sprite, gridSize, ball) { }

        public override void Update(IInputHandler _)
        {
            if (Ball.Position.X > (Position.X + Sprite.Width()))
            {
                Position = Position.Translate(1, 0);
            }
            else if (Ball.Position.X < (Position.X)) 
            {
                Position = Position.Translate(-1, 0);
            }
        }
    }
}

