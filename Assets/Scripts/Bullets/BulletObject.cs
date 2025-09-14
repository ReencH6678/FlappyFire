using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover), typeof(SpriteRenderer), typeof(Animator))]
public class BulletObject : MonoBehaviour, IPoolable
{
    private Bullet _bullet;

    private float _damage;

    private Mover _mover;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public event UnityAction<IPoolable> DeactivationRequested;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _mover.Move(_bullet.Direction.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out _))
            {
                if (_bullet.IgnorEnemy == false)
                {
                    health.TakeDamage(_bullet.Damage);
                    DeactivationRequested?.Invoke(this);
                }
            }
            else
            {
                health.TakeDamage(_bullet.Damage);
                DeactivationRequested?.Invoke(this);
            }
        }

        if(collision.gameObject.TryGetComponent<DestroyBox>(out _))
                DeactivationRequested?.Invoke(this);
    }

    public void SetBullet(Bullet bullet)
    {
        _bullet = bullet;
        _spriteRenderer.sprite = bullet.Sprite;
        _animator.runtimeAnimatorController = bullet.AnimatorController;
        _mover.SetSpeed(bullet.Speed);
        transform.localRotation = _bullet.Rotate;
    }
}
