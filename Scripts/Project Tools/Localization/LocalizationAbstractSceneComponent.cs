using UnityEngine;

namespace Project.Tools.LocalizationHelp
{
    public abstract class LocalizationAbstractSceneComponent : MonoBehaviour
    {
        protected abstract void InitLocalizationData(GameLanguage newLanguage);
        protected abstract void OnLanguageChange(GameLanguage newLanguage);
    }
}
