using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class SnakeBodyPartView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _collider;
        
        private IMemoryPool _pool;

        public double Speed { get; set; }
        public bool IsHead { get; set; }

        private void OnValidate()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _collider = gameObject.GetComponent<BoxCollider2D>();
        }

        public void OnDespawned()
        {
            // when removed from scene but saved in pool
            _pool.Despawn(this);
        }
        
        public void OnSpawned(IMemoryPool pool)
        {
            // when spawned on scene and exists in pool
            _pool = pool;
        }

        public void ReInit(SnakeProtocol protocol)
        {
            // when reused in pool
            transform.position = protocol.Position;
            _spriteRenderer.sprite = protocol.Sprite;
            Speed = protocol.Speed;
        }
        
        public void Dispose()
        {
            // when removed from pool
            _pool = null;
        }
        
        public class Pool : MemoryPool<SnakeProtocol, SnakeBodyPartView>
        {
            protected override void Reinitialize(SnakeProtocol protocol, SnakeBodyPartView item)
            {
                item.ReInit(protocol);
            }

            protected override void OnSpawned(SnakeBodyPartView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }
    }
}
