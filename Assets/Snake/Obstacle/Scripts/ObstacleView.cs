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
            transform.position = Vector3.zero;
            
            gameObject.SetActive(false);
        }

        private void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        private void ReInit(ObstacleProtocol protocol)
        {
            gameObject.SetActive(true);
            
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
            
            protected override void OnDespawned(ObstacleView item)
            {
                item.OnDespawned();
                base.OnDespawned(item);
            }

            protected override void OnSpawned(ObstacleView item)
            {
                base.OnSpawned(item);
                item.OnSpawned(this);
            }
        }
    }
}
