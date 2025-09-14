using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private string _jumpBlendParameter;
    [SerializeField] private string _attackBlendParameter;
    [SerializeField] private string _deathBlendParameter;
    [SerializeField] private string _damageBlendParameter;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(_jumpBlendParameter);
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_attackBlendParameter);
    }

    public void SetDeathParameter(bool isDie)
    {
        _animator.SetBool(_deathBlendParameter, isDie);
    }

    public void PlayDamageAnimation()
    {
        _animator.SetTrigger(_damageBlendParameter);
    }
}
