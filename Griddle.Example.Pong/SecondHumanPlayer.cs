﻿using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Input;
using Griddle.Core.Xna.Logic;
using Griddle.Core.Xna.Math;
using Microsoft.Xna.Framework.Input;

namespace Griddle.Example.Pong
{
    public class SecondHumanPlayer : Player
    {
        public SecondHumanPlayer(Sprite sprite, Vector2 gridSize, Ball ball) : base(sprite, gridSize, ball)
        {
        }

        public override void Update(IInputHandler input)
        {
            if (input.IsKeyDown(Keys.A))
            {
                var newPosition = Position.Translate(-1, 0);
                if (newPosition.X >= 0)
                {
                    Position = newPosition;
                }
            }
            else if (input.IsKeyDown(Keys.D))
            {
                var newPosition = Position.Translate(1, 0);
                if (newPosition.X < (GameSize.X - Sprite.Width()))
                {
                    Position = newPosition;
                }
            }
        }
    }
}
