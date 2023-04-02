using System;
using System.Collections;
using Interpolations;
using Maths;
using Tween;
using UnityEngine;

namespace WidgetTransitions
{
    public class FadeUtils
    {
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(1);

        public static IEnumerator HideAsync(Action<double> fade)
        {
            return StepAsync(1, 0, Duration, fade, InterpolationUtility.EaseInBack);
        }

        public static IEnumerator ShowAsync(Action<double> fade)
        {
            return StepAsync(0, 1, Duration, fade, InterpolationUtility.EaseOutBack);
        }

        private static IEnumerator StepAsync(
            int a,
            int b,
            TimeSpan duration,
            Action<double> fade,
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
                }
            );
        }
    }
}