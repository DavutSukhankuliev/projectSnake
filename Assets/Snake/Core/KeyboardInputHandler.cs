using UnityEngine;
using Zenject;

namespace Snake
{
    // todo: remove dependencies of controllers
    public class KeyboardInputHandler : ITickable
    {
        private readonly SnakeController _snakeController;
        private readonly FoodController _foodController;
        private readonly ObstacleController _obstacleController;

        public KeyboardInputHandler(
            SnakeController snakeController, 
            FoodController foodController, 
            ObstacleController obstacleController)
        {
            _snakeController = snakeController;
            _foodController = foodController;
            _obstacleController = obstacleController;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _obstacleController.Spawn(Vector3.zero, "WoodBox");
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _obstacleController.DespawnLast();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _foodController.CreateFood("Apple");
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _snakeController.CreateSnakeBodyPart();
            }
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _snakeController.MoveTo(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _snakeController.MoveTo(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _snakeController.MoveTo(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _snakeController.MoveTo(Direction.Down);
            }
        }
    }
}