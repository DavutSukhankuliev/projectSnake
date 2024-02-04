using UnityEngine;
using Zenject;

namespace Snake
{
    public class SnakeInstaller : MonoInstaller<SnakeInstaller>
    {
        [SerializeField] private SnakeConfig SnakeBodyPartConfig;
        [SerializeField] private SnakeBodyPartView SnakeBodyPartPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SnakeConfig>()
                .FromInstance(SnakeBodyPartConfig)
                .AsSingle();

            Container
                .BindMemoryPool<SnakeBodyPartView, SnakeBodyPartView.Pool>()
                .FromComponentInNewPrefab(SnakeBodyPartPrefab)
                .UnderTransformGroup("Snake");

            Container
                .BindInterfacesAndSelfTo<SnakeController>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<KeyboardInputHandler>()
                .AsSingle()
                .NonLazy();
        }
    }
}