using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class FoodView : MonoBehaviour, IDisposable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _collider;

        private FoodModel _model;
        private IMemoryPool _pool;

        private void OnValidate()
        {
            if (_spriteRenderer != null && _collider != null)
            {
                return;
            }
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _collider = gameObject.GetComponent<BoxCollider2D>();
        }

        private void OnDespawned()
        {
            _pool.Despawn(this);
        }

        private void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        private void ReInit(FoodObjectProtocol protocol)
        {
            transform.localPosition = protocol.SceneObjectProtocol.Position;
            _model = protocol.FoodModel;
            _spriteRenderer.sprite = _model.Sprite;
        }
        
        public void Dispose()
        {
            _pool = null;
        }
        
        public class Pool : MemoryPool<FoodObjectProtocol, FoodView>
        {
            protected override void Reinitialize(FoodObjectProtocol protocol, FoodView item)
            {
                item.ReInit(protocol);
            }

            protected override void OnSpawned(FoodView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }
    }
}
