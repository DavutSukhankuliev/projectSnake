using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class SnakeController : IMovable
    {
        private readonly IInstantiator _instantiator;
        private readonly SnakeConfig _snakeConfig;

        private List<SnakeBodyPartCreateCommand> _snake = new List<SnakeBodyPartCreateCommand>();

        public SnakeController(
            IInstantiator instantiator,
            SnakeConfig snakeConfig)
        {
            _instantiator = instantiator;
            _snakeConfig = snakeConfig;
        }

        public void CreateSnakeBodyPart(int number = 1)
        {
            for (int i = 0; i < number; i++)
            {
                var isSpawnedBefore = _snake.Count == 0;
                var spawnPosition = isSpawnedBefore ? Vector3.zero : _snake[^1].GetBody().transform.position;
                var spawnSprite = isSpawnedBefore ? _snakeConfig.SpriteHead : _snakeConfig.SpriteBody;
                
                var protocol = new SnakeProtocol(spawnPosition, spawnSprite, _snakeConfig.Speed);
                var command = _instantiator.Instantiate<SnakeBodyPartCreateCommand>(new object[] { protocol });
                command.Execute();
            
                var bodyPartCommand = command;
                bodyPartCommand.GetBody().IsHead = isSpawnedBefore;
                _snake.Add(bodyPartCommand);
            }
        }


        public void MoveTo(Direction direction)
        {
            var position = direction switch
            {
                Direction.Down => _snake[0].GetBody().transform.position + Vector3.down,
                Direction.Up => _snake[0].GetBody().transform.position + Vector3.up,
                Direction.Left => _snake[0].GetBody().transform.position + Vector3.left,
                Direction.Right => _snake[0].GetBody().transform.position + Vector3.right,
                _ => _snake[0].GetBody().transform.position
            };

            var prevPos = _snake[0].GetBody().transform.position;
            var desiredPos = position;
            _snake[0].GetBody().transform.position = desiredPos;

            for (var i = 1; i < _snake.Count; i++)
            {
                desiredPos = prevPos;
                prevPos = _snake[i].GetBody().transform.position;
                _snake[i].GetBody().transform.position = desiredPos;
            }
        }
    }
}