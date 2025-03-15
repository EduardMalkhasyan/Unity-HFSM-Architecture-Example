using Project.Tools.SOHelp;
using System;
using UnityEngine;

namespace Project.Settings
{
    public class UISettings : SOLoader<UISettings>
    {
        [field: SerializeField, Range(0.25f, 2f)] public float ScreenFadeDuration { get; private set; }
        [field: SerializeField, Range(0.5f, 3f)] public float EnterLoseScreenDuration { get; private set; }
    }
}

