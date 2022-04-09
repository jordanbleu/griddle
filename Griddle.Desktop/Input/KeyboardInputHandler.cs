using Griddle.Core.Xna.Input;
using Microsoft.Xna.Framework.Input;

namespace Griddle.Desktop.Input
{
    /// <summary>
    /// Monogame Keyboard input handler.  Uses the MonoGame 'keys' struct internally.  
    /// </summary>
    public class KeyboardInputHandler : IInputHandler
    {
        private KeyboardState previousState;

        public void InternalUpdate()
        {
            previousState = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys keyCode) => Keyboard.GetState().IsKeyDown(keyCode);

        public bool IsKeyHit(Keys keyCode) {
            
            // if the key is pressed but wasn't pressed in the previous frame

            var castedKey = keyCode;
            
            if (!previousState.IsKeyDown(castedKey)) { 
                return Keyboard.GetState().IsKeyDown(castedKey);
            }

            return false;
        }

        public bool IsKeyUp(Keys keyCode) {
            var castedKey = keyCode;

            if (previousState.IsKeyDown(castedKey))
            {
                return Keyboard.GetState().IsKeyUp(castedKey);
            }

            return false;

        }
    }
}
