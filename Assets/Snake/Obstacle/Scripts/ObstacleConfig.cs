using UnityEngine;

namespace Snake
{
    [CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Configs/ObstacleConfig", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private ObstacleModel _models;
    }
}