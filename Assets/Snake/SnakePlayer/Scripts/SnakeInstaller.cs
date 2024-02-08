using UnityEngine;
using Zenject;

namespace Snake
{
    public class SnakeInstaller : MonoInstaller<SnakeInstaller>
    {
        [SerializeField] private SnakeConfig _snakeBodyPartConfig;
        [SerializeField] private SnakeBodyPartView _snakeBodyPartPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SnakeConfig>()
                .FromInstance(_snakeBodyPartConfig)
                .AsSingle();

            Container
                .BindMemoryPool<SnakeBodyPartView, SnakeBodyPartView.Pool>()
                .FromComponentInNewPrefab(_snakeBodyPartPrefab)
                .UnderTransformGroup("Snake");

            Container
                .BindInterfacesAndSelfTo<SnakeController>()
                .AsSingle();
        }
    }
}