using Unity.Collections;
using Unity.Mathematics;

namespace Latios.FlowFieldNavigation
{
    public static class FlowExtensions
    {
        public static float2 GetDirection(this Flow flow, int index)
        {
            var direction = flow.DirectionMap[index];
            var rotatedDirection = math.mul(flow.Transform.Value.rotation, direction.x0y());
            return rotatedDirection.xz;
        }

        /// <summary>
        /// Samples the flow at a world position: bilinear over the four surrounding cells, scaled by
        /// per-cell crowd speed factors and attenuated by local density. Returns a world-space xz
        /// direction, or zero where the flow is negligible (goal cells and unreachable cells).
        /// </summary>
        /// <param name="flow">The flow to sample</param>
        /// <param name="field">The field the flow was built from</param>
        /// <param name="worldPosition">World-space position to sample at</param>
        public static float2 SampleDirection(this Flow flow, in Field field, float3 worldPosition)
        {
            var direction = FlowFieldInternal.SampleFlowBilinear(worldPosition, in field, in flow);
            if (math.length(direction) < 0.01f)
                return float2.zero;

            var density = FlowFieldInternal.SampleDensityBilinear(worldPosition, in field);
            var densityRatio = math.saturate(density / FlowSettings.MaxDensity);
            return direction * (1f - densityRatio * densityRatio);
        }
    }
}