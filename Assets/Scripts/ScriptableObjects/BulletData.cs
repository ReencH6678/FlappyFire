using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "New Bullet")]
public class BulletData : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private LayerMask _layerMask;

    public float Damage => _damage;
    public float Speed => _speed;
    public Sprite Sprite => _sprite;
    public AnimatorController AnimatorController => _animatorController;
    public LayerMask LayerMask => _layerMask;
}