using UnityEngine;
using Zenject;

namespace Snake
{
    public class GridController
    {
        private readonly IInstantiator _instantiator;
        private readonly GridModel _gridModel;
        private readonly GridCellModel _gridCellModel;

        private GridCellView[,] _cells;

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

        private void InitGrid()
        {
            for (int i = 0; i < _gridModel.Width; i++)
            {
                for (int j = 0; j < _gridModel.Height; j++)
                {
                    var protocol = new GridCellProtocol(new Vector3(i, j), _gridCellModel.Sprite, _gridCellModel.ColorThreshold);
                    var command = _instantiator.Instantiate<GridCellCreateCommand>(new object[] { protocol });
                    var result = command.Execute();
                    
                    //todo: return result body as GridCellView
                }
            }
        }
    }
}