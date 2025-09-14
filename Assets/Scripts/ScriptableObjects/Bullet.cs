using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "New Bullet")]
public class Bullet : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private bool _ignorEnemy;
    [SerializeField] private Quaternion _rotate;

    public float Damage => _damage;
    public float Speed => _speed;
    public Vector2 Direction => _direction;
    public Sprite Sprite => _sprite;
    public AnimatorController AnimatorController => _animatorController;
    public bool IgnorEnemy => _ignorEnemy;  
    public Quaternion Rotate => _rotate;
}