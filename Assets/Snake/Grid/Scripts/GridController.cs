using UnityEngine;
using Zenject;

namespace Snake
{
    public class GridController
    {
        private readonly IInstantiator _instantiator;
        private readonly GridModel _gridModel;
        private readonly GridCellModel _gridCellModel;

        public GridController(
            IInstantiator instantiator, 
            GridModel gridModel,
            GridCellModel gridCellModel)
        {
            _instantiator = instantiator;
            _gridModel = gridModel;
            _gridCellModel = gridCellModel;
            
            InitGrid();
        }

        public void InitGrid()
        {
            for (int i = 0; i < _gridModel.Width; i++)
            {
                for (int j = 0; j < _gridModel.Height; j++)
                {
                    var protocol = (i + j) % 2 == 1
                        ? new GridCellProtocol(new Vector3(i, j), _gridCellModel.Sprite, _gridCellModel.ColorThreshold)
                        : new GridCellProtocol(new Vector3(i, j), _gridCellModel.Sprite,
                            _gridCellModel.ColorThreshold - _gridCellModel.ColorThreshold);
                    
                    var command = _instantiator.Instantiate<GridCellCreateCommand>(new object[] { protocol });
                    var result = command.Execute();
                    
                    //todo: return result body as GridCellView and place in _cells
                    //todo: use method SetCellColor for each cell in _cells
                }
            }
        }
    }
}