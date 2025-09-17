using UnityEngine;

[RequireComponent(typeof(Jumper), typeof(InputHandler), typeof(Rigidbody2D))]
[RequireComponent(typeof(Attacker), typeof(AnimationHandler), typeof(Health))]
public class Player : Entity
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Vector2 _startPosition;

    private Jumper _jumper;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private Attacker _attacker;
    private AnimationHandler _animationHandler;
    private Health _health;

    private void Awake()
    {
        _jumper = GetComponent<Jumper>();
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _attacker = GetComponent<Attacker>();
        _animationHandler = GetComponent<AnimationHandler>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _health.Damaged += _animationHandler.PlayDamageAnimation;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _health.Damaged -= _animationHandler.PlayDamageAnimation;
    }

    private void Update()
    {
        if (IsDead == false)
            Live();
    }

    public void Reset()
    {
        _health.Reset();
        IsDead = false;
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
        _animationHandler.SetDeathParameter(false);
    }

    public override void Die()
    {
        IsDead = true;
        _animationHandler.SetDeathParameter(true);
    }

    public override void Live()
    {
        if (_inputHandler.IsLeftMouseButtonPressed)
        {
            _jumper.Jump(_rigidbody2D);
            _animationHandler.PlayJumpAnimation();
        }

        if (_inputHandler.IsRightMouseButtonPressed)
        {
            if (_attacker.CanAttack)
                _animationHandler.PlayAttackAnimation();

            _attacker.Attack(_bulletSpawner);
        }
    }
}
