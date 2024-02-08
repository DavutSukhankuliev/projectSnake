using System;
using UnityEngine;

namespace Snake
{
    [Serializable]
    public struct ObstacleModel
    {
        public string ID;
        public Sprite Sprite;

        public ObstacleModel(
            string id,
            Sprite sprite)
        {
            ID = id;
            Sprite = sprite;
        }
    }
}