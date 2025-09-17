using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover), typeof(Health), typeof(Attacker))]
[RequireComponent(typeof(AnimationHandler), typeof(Rigidbody2D))]
public class Enemy : Entity, IPoolable
{
    [SerializeField] private bool _canAttack;

    private Mover _mover;
    private Health _health;
    private BulletSpawner _bulletSpawner;
    private Attacker _attacker;
    private AnimationHandler _animationHandler;
    private Rigidbody2D _rigidbody2D;
    private Score _score;

    public event UnityAction<IPoolable> DeactivationRequested;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _health = GetComponent<Health>();
        _attacker = GetComponent<Attacker>();
        _animationHandler = GetComponent<AnimationHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsDead == false && this.enabled == true)
            Live();
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        IsDead = false;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<DestroyBox>(out _))
            DeactivationRequested?.Invoke(this);
    }

    public void SetBulletSpawner(BulletSpawner bulletSpawner)
    {
        _bulletSpawner = bulletSpawner;
    }

    public override void Die()
    {
        _rigidbody2D.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        _animationHandler.SetDeathParameter(true);
        IsDead = true;
    }

    public override void Live()
    {
        _mover.Move(Vector2.right.x);

        if (_canAttack)
            if (_attacker.CanAttack)
                _attacker.Attack(_bulletSpawner);
    }
}
