using Griddle.Core.Xna.Math;
using Griddle.Desktop;
using Griddle.Desktop.Input;
using System;

namespace Griddle.Example.Pong
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GriddleDesktopGame(new PongGame(new Vector2(16, 32), new KeyboardInputHandler())))
                game.Run();
        }
    }
}
