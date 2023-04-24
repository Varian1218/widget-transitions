using Interpolations;
using UnityEngine;

namespace Transitions.Unity
{
    public class MoveTransition : MonoBehaviour, ISerializationCallbackReceiver, ITransition
    {
        public enum Direction
        {
            Down,
            Left,
            Right,
            Up
        }

        [SerializeField] private Vector3 a;
        [SerializeField] private Vector3 b;
        [SerializeField] private Direction direction;
        [SerializeField] private RectTransform rectTransform;
        private Transition _transition;

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

        public void BeginStep(bool negative, float time)
        {
            _transition.BeginStep(negative, time);
        }

        private void Set(float f)
        {
            rectTransform.position = Vector3.LerpUnclamped(a, b, f);
        }

        public bool Step(float dt)
        {
            return _transition.Step(dt);
        }
    }
}