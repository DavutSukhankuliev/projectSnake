using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class SnakeController : IMovable
    {
        private readonly IInstantiator _instantiator;
        private readonly SnakeConfig _config;

        private List<SnakeView> _snake = new List<SnakeView>();

        public SnakeController(
            IInstantiator instantiator,
            SnakeConfig config)
        {
            _instantiator = instantiator;
            _config = config;
        }

        public void InitSnake()
        {
            var protocol = new SnakeProtocol(Vector3.zero, _config.SpriteHead, _config.SpriteBody, _config.Speed);
            var command = _instantiator.Instantiate<SnakeCreateCommand>(new object[] { protocol });
            command.Execute();
            
            var head = command.GetBody();
            head.IsHead = true;
            _snake.Add(head);
        }


        public void MoveTo(Direction direction)
        {
            var position = direction switch
            {
                Direction.Down => _snake[0].transform.position + Vector3.down,
                Direction.Up => _snake[0].transform.position + Vector3.up,
                Direction.Left => _snake[0].transform.position + Vector3.left,
                Direction.Right => _snake[0].transform.position + Vector3.right,
                _ => _snake[0].transform.position
            };

            var desiredPos = position;
            var prevPos = position;
            for (int i = 0; i < _snake.Count; i++)
            {
                if (i == 0)
                {
                    prevPos = _snake[i].transform.position;
                    desiredPos = position;
                    _snake[i].transform.position = desiredPos;
                }
                else
                {
                    desiredPos = prevPos;
                    prevPos = _snake[i].transform.position;
                    _snake[i].transform.position = desiredPos;
                }
            }
        }

        public void AddBody(Vector3 pos)
        {
            var protocol = new SnakeProtocol(pos, _config.SpriteHead, _config.SpriteBody, _config.Speed);
            var command = _instantiator.Instantiate<SnakeCreateCommand>(new object[] { protocol });
            command.Execute();
            
            var head = command.GetBody();
            head.IsHead = false;
            _snake.Add(head);
        }
    }
}