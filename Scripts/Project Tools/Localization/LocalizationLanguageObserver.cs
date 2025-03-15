using System;

namespace Project.Tools.LocalizationHelp
{
    public static class LocalizationLanguageObserver
    {
        public static event Action<GameLanguage> OnLanguageChange;

        public static void OnLanguageChangeInvoke(GameLanguage value)
        {
            OnLanguageChange?.Invoke(value);
        }
    }
}
