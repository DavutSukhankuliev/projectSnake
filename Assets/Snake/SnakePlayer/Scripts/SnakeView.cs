using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SnakeView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;

        private IMemoryPool _pool;

        public bool IsHead { get; set; }

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
            _spriteRenderer.sprite = IsHead ? protocol.SpriteHead : protocol.SpriteBody;
        }
        
        public void Dispose()
        {
            // when removed from pool
            _pool = null;
        }
        
        public class Pool : MemoryPool<SnakeProtocol, SnakeView>
        {
            protected override void Reinitialize(SnakeProtocol protocol, SnakeView item)
            {
                item.ReInit(protocol);
            }

            protected override void OnSpawned(SnakeView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }
    }
}
