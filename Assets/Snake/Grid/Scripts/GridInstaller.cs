using UnityEngine;
using Zenject;

namespace Snake
{
    public class GridInstaller : MonoInstaller<GridInstaller>
    {
        [SerializeField] private GridCellView _gridCellViewPrototype;
        [SerializeField] private GridCellModel _cellConfig;
        [SerializeField] private GridModel _gridConfig;
    
        public override void InstallBindings()
        {
            Container
                .Bind<GridCellModel>()
                .FromInstance(_cellConfig)
                .AsSingle();
            
            Container
                .Bind<GridModel>()
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