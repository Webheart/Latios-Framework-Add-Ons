using System;
using Unity.Mathematics;
using UnityEngine;

namespace Latios.FlowFieldNavigation
{
    [Serializable]
    public struct FlowSettings
    {
        internal const float PassabilityLimit = 500000;
        internal const int MaxFootprintSize = 10;
        internal const int MaxDensity = 10;
        /// <summary>Potential-gradient length that maps to full flow strength; flatter spots yield proportionally weaker directions.</summary>
        internal const float FullStrengthGradient = 1f;

        [Range(0, 10)]
        public float DensityInfluence;

        /// <summary>Wavefront-cost band around goals (in cells) where flow strength fades to zero; 0 disables.</summary>
        [Min(0)]
        public float ArrivalBand;

        public static FlowSettings Default => new()
        {
            DensityInfluence = 1f,
        };
    }
}