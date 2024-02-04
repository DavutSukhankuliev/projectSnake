using UnityEngine;
using Zenject;

namespace Snake
{
    public class GridController
    {
        private readonly IInstantiator _instantiator;
        private readonly GridConfig _gridConfig;
        private readonly GridCellConfig _gridCellConfig;

        public GridController(
            IInstantiator instantiator, 
            GridConfig gridConfig,
            GridCellConfig gridCellConfig)
        {
            _instantiator = instantiator;
            _gridConfig = gridConfig;
            _gridCellConfig = gridCellConfig;
            
            InitGrid();
        }

        public void InitGrid()
        {
            for (int i = 0; i < _gridConfig.Width; i++)
            {
                for (int j = 0; j < _gridConfig.Height; j++)
                {
                    var protocol = (i + j) % 2 == 1
                        ? new GridCellProtocol(new Vector3(i, j), _gridCellConfig.Sprite, _gridCellConfig.ColorThreshold)
                        : new GridCellProtocol(new Vector3(i, j), _gridCellConfig.Sprite,
                            _gridCellConfig.ColorThreshold - _gridCellConfig.ColorThreshold);
                    
                    var command = _instantiator.Instantiate<GridCellCreateCommand>(new object[] { protocol });
                    var result = command.Execute();
                    
                    //todo: return result body as GridCellView and place in _cells
                    //todo: use method SetCellColor for each cell in _cells
                }
            }
        }
    }
}