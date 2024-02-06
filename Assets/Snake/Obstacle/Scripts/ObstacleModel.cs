using UnityEngine;

namespace Snake
{
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