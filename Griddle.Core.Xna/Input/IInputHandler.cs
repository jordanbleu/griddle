using Microsoft.Xna.Framework.Input;

namespace Griddle.Core.Xna.Input
{
    /// <summary>
    /// Interface for checking for inputs from various sources.  Makes the bold assumption that every keycode can 
    /// be inferred from a given int, which as far as i've seen has always been true. 
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Check if a key is pressed down but not held
        /// </summary>
        bool IsKeyHit(Keys keyCode);

        /// <summary>
        /// Check if a key is pressed and held
        /// </summary>
        bool IsKeyDown(Keys keyCode);

        /// <summary>
        /// Check if a key is released 
        /// </summary>
        bool IsKeyUp(Keys keyCode);

        void InternalUpdate();
    }
}
