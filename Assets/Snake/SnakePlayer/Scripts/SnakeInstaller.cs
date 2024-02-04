using UnityEngine;
using Zenject;

namespace Snake
{
    public class SnakeInstaller : MonoInstaller<SnakeInstaller>
    {
        [SerializeField] private SnakeConfig _snakeConfig;
        [SerializeField] private SnakeView _snakePrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SnakeConfig>()
                .FromInstance(_snakeConfig)
                .AsSingle();

            Container
                .BindMemoryPool<SnakeView, SnakeView.Pool>()
                .FromComponentInNewPrefab(_snakePrefab)
                .UnderTransformGroup("Snake");

            Container
                .BindInterfacesAndSelfTo<SnakeController>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<InputHandler>()
                .AsSingle()
                .NonLazy();
        }
    }
}