using System;
using UnityEngine;

namespace Project.Settings
{
    [Serializable]
    public class LevelPreset
    {
        [field: SerializeField] public int LevelIndex { get; private set; }
    }
}

