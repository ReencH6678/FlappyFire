using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover), typeof(SpriteRenderer), typeof(Animator))]
public class Bullet : MonoBehaviour, IPoolable
{
    private BulletData _bullet;

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
        _mover.Move(Vector2.right.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(_bullet.Damage);
            DeactivationRequested?.Invoke(this);
        }

        if (collision.gameObject.TryGetComponent<DestroyBox>(out _))
            DeactivationRequested?.Invoke(this);
    }

    public void SetBullet(BulletData bullet)
    {
        int logVelue = 2;

        _bullet = bullet;
        _spriteRenderer.sprite = bullet.Sprite;
        _animator.runtimeAnimatorController = bullet.AnimatorController;
        _mover.SetSpeed(bullet.Speed);
        gameObject.layer = (int)Mathf.Log(_bullet.LayerMask.value, logVelue);
    }

    public void SetDirection(Quaternion rotation)
    {
        transform.localRotation = rotation;
    }
}
