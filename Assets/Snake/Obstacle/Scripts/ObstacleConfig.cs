using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Configs/ObstacleConfig", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private ObstacleModel[] _models;

        public ObstacleModel[] Models => _models;
        
        private bool _isInit = false;
        private Dictionary<string, ObstacleModel> _dictionary = new Dictionary<string, ObstacleModel>();

        private void OnValidate()
        {
            _isInit = false;
        }

        public ObstacleModel Get(string id)
        {
            if (!_isInit)
            {
                Init();
            }
            
            if (_dictionary.TryGetValue(id, out var value))
            {
                return value;
            }
            Debug.LogError($"Couldn't find ObstacleModel with name {id}");
            return new ObstacleModel();
        }

        private void Init()
        {
            foreach (var model in _models)
            {
                _dictionary.Add(model.ID, model);
            }
            _isInit = true;
        }
    }
}