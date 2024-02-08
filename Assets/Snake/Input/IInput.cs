using System;

namespace Snake
{
    public interface IInput
    {
        event Action<InputDirection> InputDirectionChange;
    }
}