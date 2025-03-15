using Project.Tools.AttributeHelp;
using Project.Tools.SOHelp;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Project.Settings
{
    public class LayerMaskNamesSettings : SOLoader<LayerMaskNamesSettings>
    {
        [ShowInInspector, ReadOnly] public readonly string Everything = "Everything";
        public int EverythingLayer => LayerMask.NameToLayer(Everything);

        [Layer, SerializeField] private int defaultLayer;
        public int DefaultLayer => defaultLayer;

        [Layer, SerializeField] private int groundLayer;
        public int GroundLayer => groundLayer;

        [SerializeField] private LayerMask uILayer;
        public LayerMask UILayer => uILayer;

        [Button]
        public LayerMask GroundLayers()
        {
            int combinedMask = (1 << DefaultLayer) | (1 << GroundLayer);
            return combinedMask;
        }
    }
}
