using Griddle.Core.Xna.Graphics;
using Griddle.Core.Xna.Input;
using Griddle.Core.Xna.Math;

namespace Griddle.Core.Xna.Runtime
{
    public abstract class GriddleGame
    {
        private bool isInitialized = false;

        private IInputHandler inputHandler; 
        
        /// <summary>
        /// Returns the injected input handler for checking user inputs
        /// </summary>
        public IInputHandler Input { get { return inputHandler; } }  

        public GriddleGame(Vector2 size, IInputHandler inputHandler = null)
        {
            Grid = new Grid(new Vector2(size.X,size.Y));
            this.inputHandler = inputHandler;
        }

        public Grid Grid { get; private set; }

        /// <summary>
        /// The title of your game.  What this does varies based on the runtime, but for Desktop games this will 
        /// be shown in the title bar.
        /// </summary>
        public string GameTitle { get; set; }

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
            // update the inputs if we have an input handler
            if (inputHandler != null) {
                inputHandler.InternalUpdate();
            }

            GameUpdate();

            // update pixels on the grid based on the active sprites
            Grid.Refresh();
        }


    }
}
