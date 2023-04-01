using System;
using System.Collections;
using Doubles;
using Interpolations;
using Maths;
using Tween;
using UnityEngine;

namespace WidgetTransitions
{
    public static class FadeScaleUtils
    {
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(1); 
        public static IEnumerator HideAsync(Action<double> fade, Action<Double3> scale)
        {
            return StepAsync(1, 0, Duration, fade, scale, InterpolationUtility.EaseInBack);
        }

        public static IEnumerator ShowAsync(Action<double> fade, Action<Double3> scale)
        {
            return StepAsync(0, 1, Duration, fade, scale, InterpolationUtility.EaseOutBack);
        }

        private static IEnumerator StepAsync(
            int a,
            int b,
            TimeSpan duration,
            Action<double> fade,
            Action<Double3> scale,
            Func<float, float> interpolate
        )
        {
            return TweenUtils.DoAsync(
                duration,
                () => TimeSpan.FromSeconds(Time.deltaTime),
                value =>
                {
                    var it = interpolate((float)value);
                    fade(MathUtils.Lerp(a, b, it));
                    scale(Double3.Lerp(Double3.One * a, Double3.One * b, it));
                }
            );
        }
    }
}