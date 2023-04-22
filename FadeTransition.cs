using Interpolations;
using UnityEngine;
using UnityEngine.Events;

namespace WidgetTransitions
{
    public class FadeTransition : MonoBehaviour, ISerializationCallbackReceiver, ITransition
    {
        [SerializeField] private UnityEvent<float> fade;
        private Transition _transition;

        public void BeginStep(bool negative, float time)
        {
            _transition.BeginStep(negative, time);
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            _transition = new Transition
            {
                Interpolate = InterpolationUtility.EaseOutBack,
                Set = fade.Invoke
            };
        }

        public bool Step(float dt)
        {
            return _transition.Step(dt);
        }
    }
}