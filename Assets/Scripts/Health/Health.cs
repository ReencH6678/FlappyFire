using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxCount;
    public float Count { get; private set; }
    public event Action<float, float> Changed;

    public event Action Damaged;
    public event Action Died;

    private void Start()
    {
        Count = _maxCount;
        Changed?.Invoke(Count, _maxCount);
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Count -= damage;
            Changed?.Invoke(Count, _maxCount);
            Damaged?.Invoke();
        }

        if (Count <= 0)
            Died?.Invoke();
    }

    public void Heal(float healCount)
    {
        if (healCount > 0 && healCount + Count <= _maxCount)
        {
            Count += healCount;
            Changed?.Invoke(Count, _maxCount);
        }
    }

    public void Kill()
    {
        Died?.Invoke();
    }

    public void Reset()
    {
        Count = _maxCount;
        Changed?.Invoke(Count, _maxCount);
    }
}
