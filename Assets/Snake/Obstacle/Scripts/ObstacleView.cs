using UnityEngine;
using Zenject;

namespace Snake
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _collider;

        private IMemoryPool _pool;
        
        private void OnValidate()
        {
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

        private void ReInit(ObstacleProtocol protocol)
        {
            transform.position = protocol.SceneObjectProtocol.Position;
            _spriteRenderer.sprite = protocol.ObstacleModel.Sprite;
        }

        private void Dispose()
        {
            _pool = null;
        }
        
        public class Pool : MemoryPool<ObstacleProtocol, ObstacleView>
        {
            protected override void Reinitialize(ObstacleProtocol protocol, ObstacleView item)
            {
                item.ReInit(protocol);
            }

            protected override void OnSpawned(ObstacleView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }
    }
}
