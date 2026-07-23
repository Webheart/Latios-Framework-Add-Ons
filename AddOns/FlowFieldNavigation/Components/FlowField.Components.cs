using Unity.Entities;
using Unity.Mathematics;

namespace Latios.FlowFieldNavigation
{
    public static partial class FlowField
    {
        public struct Goal : IComponentData
        {
            public int2 Size;
        }

        public struct AgentDirection : IComponentData
        {
            public float2 Value;
        }

        public struct AgentFootprint : IComponentData
        {
            public int Size;
        }
        
        /// <summary>
        /// Density stamp weights: the radial profile falls off from MaxWeight at the agent position
        /// to MinWeight at the footprint rim. A 1-cell footprint contributes plain MaxWeight.
        /// </summary>
        public struct AgentDensity : IComponentData
        {
            public float MinWeight;
            public float MaxWeight;
        }

        public struct PrevPosition : IComponentData
        {
            public float2 Value;
        }

        public struct Velocity : IComponentData
        {
            public float2 Value;
        }
    }
}