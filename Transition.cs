using System;

namespace WidgetTransitions
{
    public class Transition : ITransition
    {
        private bool _negative;
        private float _now;
        private int _factor;
        private Func<float, float> _interpolate;
        private Action<float> _set;
        private float _time;

        public Func<float, float> Interpolate
        {
            set => _interpolate = value;
        }

        public Action<float> Set
        {
            set => _set = value;
        }

        public void BeginStep(bool negative, float time)
        {
            _factor = negative ? -1 : 1;
            _negative = negative;
            _now = negative ? 1 : 0;
            _time = time;
        }

        public bool Step(float dt)
        {
            _now += dt * _factor;
            if (_now > 0f && _now < _time)
            {
                _set(_interpolate(_now / _time));
                return false;
            }

            _set(_negative ? 0 : 1);
            return true;
        }
    }
}