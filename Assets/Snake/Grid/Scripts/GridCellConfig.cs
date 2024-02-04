using UnityEngine;

namespace Snake
{
    public struct GridCellProtocol
    {
        public Vector3 LocalPosition;
        public Sprite Sprite;
        public float ColorThreshold;

        public GridCellProtocol(
            Vector3 localPosition,
            Sprite sprite, 
            float colorThreshold)
        {
            LocalPosition = localPosition;
            Sprite = sprite;
            ColorThreshold = colorThreshold;
        }
    }
    
    [CreateAssetMenu(fileName = "GridCellConfig", menuName = "Configs/GridCellConfig", order = 0)]
    public class GridCellConfig : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField, Range (-0.5f,0.5f)] private float _colorThreshold;

        public Sprite Sprite => _sprite;
        public float ColorThreshold => _colorThreshold;
    }
}