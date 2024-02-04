using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GridCellView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private IMemoryPool _pool;

        public float ColorThreshold { get; private set; }

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
            ColorThreshold = protocol.ColorThreshold;
            
            SetCellColor();
        }
        
        public void Dispose()
        {
            // when removed from pool
            _pool = null;
        }

        private void SetCellColor()
        {
            var color = _spriteRenderer.color;
            color = new Color(color.r + ColorThreshold,
                color.g + ColorThreshold, color.b + ColorThreshold);
            _spriteRenderer.color = color;
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
    }
}
