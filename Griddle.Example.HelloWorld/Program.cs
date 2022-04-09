using Griddle.Core.Xna.Math;
using Griddle.Desktop;
using System;

namespace Griddle.Example.HelloWorld
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new GriddleDesktopGame(
                new HelloWorldGame(size: new Vector2(16,16))
            ); 

            game.Run();
        }
    }
}
