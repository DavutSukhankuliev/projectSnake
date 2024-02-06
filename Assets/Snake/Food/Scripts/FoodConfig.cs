using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    [Serializable]
    public struct FoodModel
    {
        public string ID;
        public Sprite Sprite;
        public int Points;
        public int SnakeSizeValue;
        public float SpeedValue;
        public bool IsGhost;
        public bool ChangeHead;
    }
    
    [CreateAssetMenu(fileName = "FoodConfig", menuName = "Configs/FoodConfig", order = 0)]
    public class FoodConfig : ScriptableObject
    {
        [SerializeField] private FoodModel[] _foodModels;
        
        private bool _isInit = false;
        private Dictionary<string, FoodModel> _dictionary = new Dictionary<string, FoodModel>();

        private void OnValidate()
        {
            _isInit = false;
        }

        public FoodModel Get(string id)
        {
            if (!_isInit)
            {
                Init();
            }
            
            if (_dictionary.TryGetValue(id, out var value))
            {
                return value;
            }
            Debug.LogError($"Couldn't find FoodModel with name {id}");
            return new FoodModel();
        }

        private void Init()
        {
            foreach (var foodModel in _foodModels)
            {
                _dictionary.Add(foodModel.ID, foodModel);
            }
            _isInit = true;
        }
    }
}