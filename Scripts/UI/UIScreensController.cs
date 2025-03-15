using Project.Tools;
using Project.Tools.DictionaryHelp;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Project.UI
{
    public class UIScreensController : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<UIScreenEnum, UIScreen> uIScreensKVP;
        [SerializeField, ReadOnly] private UIScreen currentScreen;

        public void Setup()
        {
            foreach (var uiScreen in uIScreensKVP)
            {
                uiScreen.Value.HideInstant();
            }
        }

        public void ShowUIScreen(UIScreenEnum uIScreenEnum, Action OnCompleteCB = null)
        {
            if (currentScreen == null)
            {
                currentScreen = uIScreensKVP[uIScreenEnum];
                currentScreen.Show(() =>
                {
                    OnCompleteCB?.Invoke();
                });
            }

            if (currentScreen != uIScreensKVP[uIScreenEnum])
            {
                currentScreen.Hide(() =>
                {
                    uIScreensKVP[uIScreenEnum].Show();
                    currentScreen = uIScreensKVP[uIScreenEnum];
                    OnCompleteCB?.Invoke();
                });
            }
        }

        public void ShowUIScreenWithDelay(UIScreenEnum uIScreenEnum, Action OnCompleteCB = null, float delay = 0)
        {
            if (currentScreen == null)
            {
                currentScreen = uIScreensKVP[uIScreenEnum];
                currentScreen.ShowWithDelay(() =>
                {
                    OnCompleteCB?.Invoke();
                }, delay);
            }

            if (currentScreen != uIScreensKVP[uIScreenEnum])
            {
                currentScreen.Hide(() =>
                {
                    uIScreensKVP[uIScreenEnum].ShowWithDelay(interval: delay);
                    currentScreen = uIScreensKVP[uIScreenEnum];
                    OnCompleteCB?.Invoke();
                });
            }
        }

        public void ShowInstantUIScreen(UIScreenEnum uIScreenEnum, Action OnCompleteCB = null)
        {
            if (currentScreen == null)
            {
                currentScreen = uIScreensKVP[uIScreenEnum];
                currentScreen.ShowInstant(() =>
                {
                    OnCompleteCB?.Invoke();
                });
            }

            if (currentScreen != uIScreensKVP[uIScreenEnum])
            {
                currentScreen.HideInstant(() =>
                {
                    uIScreensKVP[uIScreenEnum].ShowInstant();
                    currentScreen = uIScreensKVP[uIScreenEnum];
                    OnCompleteCB?.Invoke();
                });
            }
        }
    }
}

