using UnityEngine;

namespace Snake
{
    public struct GridProtocol
    {
        public Vector3 Position;
        public int Width;
        public int Height;
        public float CellSizeFactor;

        public GridProtocol(
            Vector3 position, 
            int width, 
            int height, 
            float cellSizeFactor)
        {
            Position = position;
            Width = width;
            Height = height;
            CellSizeFactor = cellSizeFactor;
        }
    }
    
    [CreateAssetMenu(fileName = "GridModel", menuName = "Configs/GridModel", order = 0)]
    public class GridModel : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private float _cellSizeFactor;

        public int Width => _width;
        public int Height => _height;
        public float CellSizeFactor => _cellSizeFactor;

        private void OnValidate()
        {
            if (Width < 0)
            {
                _width = -_width;
            }

            if (Height < 0)
            {
                _height = -_height;
            }

            if (CellSizeFactor < 0)
            {
                _cellSizeFactor = -_cellSizeFactor;
            }
        }
    }
}