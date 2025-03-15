using System;

namespace Project.Player.Observer
{
    public static class PlayerObserver
    {
        public static event Action OnResetComplete;
        public static event Action OnLevelFinish;

        public static void InvokeOnResetComplete()
        {
            OnResetComplete?.Invoke();
        }

        public static void InvokeOnLevelFinish()
        {
            OnLevelFinish?.Invoke();
        }
    }
}
