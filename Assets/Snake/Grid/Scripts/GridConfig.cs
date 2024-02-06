using UnityEngine;

namespace Snake
{
    public struct GridProtocol
    {
        public Vector3 Position;
        public int Width;
        public int Height;

        public GridProtocol(
            Vector3 position, 
            int width, 
            int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }
    
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/GridConfig", order = 0)]
    public class GridConfig : ScriptableObject
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        public int Width => _width;
        public int Height => _height;

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
        }
    }
}