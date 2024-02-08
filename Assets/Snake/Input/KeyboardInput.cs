using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class KeyboardInput : IInput, ITickable
    {
        public event Action<InputDirection> InputDirectionChange;
        
        //Test
        private bool _snakeIsMoved = false;
        
        private readonly SnakeController _snakeController;
        private readonly FoodController _foodController;
        private readonly ObstacleController _obstacleController;

        public KeyboardInput(SnakeController snakeController, FoodController foodController, ObstacleController obstacleController)
        {
            _snakeController = snakeController;
            _foodController = foodController;
            _obstacleController = obstacleController;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!_snakeIsMoved)
                {
                    _snakeController.MoveTo(MovementDirection.Left);
                    _snakeIsMoved = true;
                }
                else
                {
                    InputDirectionChange?.Invoke(InputDirection.Left);
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!_snakeIsMoved)
                {
                    _snakeController.MoveTo(MovementDirection.Right);
                    _snakeIsMoved = true;
                }
                else
                {
                    InputDirectionChange?.Invoke(InputDirection.Right);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!_snakeIsMoved) _snakeController.MoveTo(MovementDirection.Up); 
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!_snakeIsMoved) _snakeController.MoveTo(MovementDirection.Down);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                _obstacleController.Spawn(Vector3.zero, "WoodBox");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _obstacleController.DespawnLast();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _foodController.CreateFood("Apple");
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _snakeController.CreateSnakeBodyPart();
            }
        }
    }
}