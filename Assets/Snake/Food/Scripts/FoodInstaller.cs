using UnityEngine;
using Zenject;

namespace Snake
{
    public class FoodInstaller : MonoInstaller<FoodInstaller>
    {
        [SerializeField] private FoodView _prefab;
        [SerializeField] private FoodConfig _config;
    
        public override void InstallBindings()
        {
            Container
                .Bind<FoodConfig>()
                .FromInstance(_config)
                .AsSingle();
            
            Container
                .BindMemoryPool<FoodView, FoodView.Pool>()
                .FromComponentInNewPrefab(_prefab)
                .UnderTransformGroup("Food");

            Container
                .Bind<FoodController>()
                .AsSingle()
                .NonLazy();
        }
    }
}