namespace Modules.States
{
    public abstract class GameState
    {
        public bool Check<T>(out T state) where T : GameState
        {
            if (this is T)
            {
                state = (T)this;
                return true;
            }

            state = null;
            return false;
        }

        public bool Check<T>() where T : GameState
        {
            return this is T;
        }
    }
}
