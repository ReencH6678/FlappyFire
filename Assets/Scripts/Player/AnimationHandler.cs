using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayJumpAnimation()
    {
        _animator.SetTrigger(AnimatorData.Param.Jump);
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(AnimatorData.Param.Attack);
    }

    public void SetDeathParameter(bool isDie)
    {
        _animator.SetBool(AnimatorData.Param.Death, isDie);
    }

    public void PlayDamageAnimation()
    {
        _animator.SetTrigger(AnimatorData.Param.Damaged);
    }
}
