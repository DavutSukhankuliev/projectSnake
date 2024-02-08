using UnityEngine;
using Zenject;

namespace Snake
{
    public class ObstacleInstaller : MonoInstaller<ObstacleInstaller>
    {
        [SerializeField] private ObstacleConfig _config;
        [SerializeField] private ObstacleView _prefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ObstacleConfig>()
                .FromInstance(_config)
                .AsSingle();

            Container
                .BindMemoryPool<ObstacleView, ObstacleView.Pool>()
                .FromComponentInNewPrefab(_prefab)
                .UnderTransformGroup("Obstacles");

            Container
                .BindInterfacesAndSelfTo<ObstacleController>()
                .AsSingle();
        }
    }
}