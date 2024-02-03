using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GridCellView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private float _colorThreshold;
        private IMemoryPool _pool;

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

        public void ReInit(GridCellProtocol protocol)
        {
            // when reused in pool
            transform.position = protocol.LocalPosition;
            _spriteRenderer.sprite = protocol.Sprite;
            _colorThreshold = protocol.ColorThreshold;
        }
        
        public void Dispose()
        {
            // when removed from pool
            _pool = null;
        }
        
        public class Pool : MemoryPool<GridCellProtocol, GridCellView>
        {
            protected override void Reinitialize(GridCellProtocol protocol, GridCellView item)
            {
                item.ReInit(protocol);
            }

            protected override void OnSpawned(GridCellView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }

        public class Factory : PlaceholderFactory<GridCellProtocol, GridCellView>
        {
        }
    }
}
