using UnityEngine;
using Zenject;

namespace Snake
{
    // todo: remove dependency of snakecontroller
    public class KeyboardInputHandler : ITickable
    {
        private readonly SnakeController _snakeController;

        public KeyboardInputHandler(SnakeController snakeController)
        {
            _snakeController = snakeController;
        }

        public void Tick()
        {
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