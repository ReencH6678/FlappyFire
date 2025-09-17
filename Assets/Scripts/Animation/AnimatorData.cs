using UnityEngine;

public static class AnimatorData
{
    public static class Param
    {
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Death = Animator.StringToHash(nameof(Death));
        public static readonly int Damaged = Animator.StringToHash(nameof(Damaged));
    }
}
