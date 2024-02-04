using System;
using UnityEngine;

namespace Snake
{
    public struct SnakeProtocol
    {
        public Vector3 Position;
        public Sprite SpriteHead;
        public Sprite SpriteBody;
        public double Speed;

        public SnakeProtocol(
            Vector3 position,
            Sprite spriteHead,
            Sprite spriteBody,
            double speed)
        {
            Position = position;
            SpriteHead = spriteHead;
            SpriteBody = spriteBody;
            Speed = speed;
        }
    }
    
    [CreateAssetMenu(fileName = "SnakeConfig", menuName = "Configs/SnakeConfig", order = 0)]
    public class SnakeConfig : ScriptableObject
    {
        [SerializeField] private Sprite _spriteHead;
        [SerializeField] private Sprite _spriteBody;
        [SerializeField, Range(0, 10)] private double _speed;
        [SerializeField] private int _initLength;

        public Sprite SpriteHead => _spriteHead;
        public Sprite SpriteBody => _spriteBody;
        public double Speed => _speed;

        private void OnValidate()
        {
            if (_speed < 0)
            {
                _speed = -_speed;
            }

            if (_initLength < 0)
            {
                _initLength = -_initLength;
            }
        }
    }
}