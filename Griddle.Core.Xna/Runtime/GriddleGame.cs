using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Math;
using System.Threading;

namespace Griddle.Core.Xna.Runtime
{
    public abstract class GriddleGame
    {

        private bool isInitialized = false;

        public GriddleGame(Vector2 size)
        {
            Grid = new Grid(new Vector2(size.X,size.Y));
        }

        public Grid Grid { get; private set; }

        /// <summary>
        /// Determines how fast updates should occur.  
        /// </summary>
        public int Delay { get; set; } = 100;

        public bool IsRunning { get; set; } = true;

        /// <summary>
        /// Perform game logic updates here.  This method will be run once per frame.
        /// </summary>
        protected abstract void GameUpdate();

        /// <summary>
        /// Perform game initialization here.
        /// </summary>
        public abstract void GameInitialize();

        /// <summary>
        /// Call this method to run your game.  
        /// </summary>
        public void Run()
        {

            if (!isInitialized)
            {
                GameInitialize();
                isInitialized = true;
            }

            // This is the main game loop, it's very simple
            while (IsRunning)
            {
                Update();
            }
        }


        public void Update()
        {
            GameUpdate();

            // update pixels on the grid based on the active sprites
            Grid.Refresh();
        }

    }
}
