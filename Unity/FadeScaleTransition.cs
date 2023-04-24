using Interpolations;
using UnityEngine;
using UnityEngine.Events;

namespace Transitions
{
    public class FadeScaleTransition : MonoBehaviour, ISerializationCallbackReceiver, ITransition
    {
        [SerializeField] private UnityEvent<float> fade;
        [SerializeField] private Transform scale;
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
                Set = Set
            };
        }

        private void Set(float f)
        {
            fade.Invoke(f);
            scale.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, f);
        }

        public bool Step(float dt)
        {
            return _transition.Step(dt);
        }
    }
}