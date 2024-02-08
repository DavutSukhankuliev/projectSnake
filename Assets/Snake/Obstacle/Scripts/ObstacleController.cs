using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class ObstacleController
    {
        private readonly IInstantiator _instantiator;
        private readonly ObstacleConfig _config;

        private List<ObstacleCreateCommand> _obstacles = new List<ObstacleCreateCommand>();

        public ObstacleController(
            IInstantiator instantiator, 
            ObstacleConfig config)
        {
            _instantiator = instantiator;
            _config = config;
        }

        public void Spawn(Vector3 position, string id)
        {
            var protocol = new ObstacleProtocol(new SceneObjectProtocol(position), _config.Get(id));
            var command = _instantiator.Instantiate<ObstacleCreateCommand>(new object[] { protocol });
            command.Execute();
            
            _obstacles.Add(command);
        }

        public void DespawnLast()
        {
            if (_obstacles.Count == 0)
            {
                Debug.LogError($"Couldn't despawn ObstacleView. There are no ObstacleViews");
                return;
            }
            
            _obstacles[^1].Redo();
            _obstacles.RemoveAt(_obstacles.Count - 1);
        }
        
        public void DespawnLastNumber(int number = 1)
        {
            if (_obstacles.Count < number)
            {
                Debug.LogError($"Couldn't despawn ObstacleView. There are less ObstacleViews than {number}");
                return;
            }
            
            for (int i = 0; i < number; i++)
            {
                _obstacles[^1].Redo();
                _obstacles.RemoveAt(_obstacles.Count - 1);
            }
        }
    }
}