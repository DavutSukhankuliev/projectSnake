using UnityEngine;
using Zenject;

namespace Snake
{
    public class GridInstaller : MonoInstaller<GridInstaller>
    {
        [SerializeField] private GridCellView _gridCellViewPrototype;
        [SerializeField] private GridCellConfig _cellConfig;
        [SerializeField] private GridConfig _gridConfig;
    
        public override void InstallBindings()
        {
            Container
                .Bind<GridCellConfig>()
                .FromInstance(_cellConfig)
                .AsSingle();
            
            Container
                .Bind<GridConfig>()
                .FromInstance(_gridConfig)
                .AsSingle();

            Container
                .BindMemoryPool<GridCellView, GridCellView.Pool>()
                .WithInitialSize((_gridConfig.Width - 1) * (_gridConfig.Height - 1))
                .FromComponentInNewPrefab(_gridCellViewPrototype)
                .UnderTransformGroup("Grid");

            Container
                .Bind<GridController>()
                .AsSingle()
                .NonLazy();
        }
    }
}