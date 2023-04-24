﻿namespace Transitions
{
    public interface ITransition
    {
        void BeginStep(bool negative, float time);
        bool Step(float dt);
    }
}