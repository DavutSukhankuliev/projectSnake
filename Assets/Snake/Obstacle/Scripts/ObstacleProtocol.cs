using UnityEngine;

namespace Snake
{
    public struct ObstacleProtocol
    {
        public SceneObjectProtocol SceneObjectProtocol;
        public ObstacleModel ObstacleModel;

        public ObstacleProtocol(
            SceneObjectProtocol sceneObjectProtocol, 
            ObstacleModel obstacleModel)
        {
            SceneObjectProtocol = sceneObjectProtocol;
            ObstacleModel = obstacleModel;
        }
    }
}