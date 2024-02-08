using System;
using UnityEngine;

namespace Snake
{
    public class MovementHandler : IDisposable
    {
        private readonly IInput _input;
        private readonly IMovable _movable;

        public MovementHandler(
            IInput input, 
            IMovable movable)
        {
            _input = input;
            _movable = movable;

            _input.InputDirectionChange += OnInputDirectionChanged;
        }

        public void OnInputDirectionChanged(InputDirection inputDirection)
        {
            MovementDirection newDirection = _movable.CurrentDirection;
            
            switch (_movable.CurrentDirection)
            {
                case MovementDirection.Right when inputDirection == InputDirection.Left:
                case MovementDirection.Left when inputDirection == InputDirection.Right:
                    newDirection = MovementDirection.Up;
                    break;
                case MovementDirection.Left when inputDirection == InputDirection.Left:
                case MovementDirection.Right when inputDirection == InputDirection.Right:
                    newDirection = MovementDirection.Down;
                    break;
                case MovementDirection.Up when inputDirection == InputDirection.Right:
                case MovementDirection.Down when inputDirection == InputDirection.Left:
                    newDirection = MovementDirection.Right;
                    break;
                case MovementDirection.Up when inputDirection == InputDirection.Left:
                case MovementDirection.Down when inputDirection == InputDirection.Right:
                    newDirection = MovementDirection.Left;
                    break;
                default:
                    Debug.LogError($"Couldn't handle input {inputDirection} while movement was {_movable.CurrentDirection}");
                    break;
            }
            
            _movable.MoveTo(newDirection);
        }
        
        public void Dispose()
        {
            _input.InputDirectionChange -= OnInputDirectionChanged;
        }
    }
}