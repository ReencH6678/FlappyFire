using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const int StartCount = 0;

    [SerializeField] private EnemySpawner _enemySpawner;

    private int _count;

    public event UnityAction<int> Changed;

    private void OnEnable()
    {
        _enemySpawner.Released += Add;
    }

    private void OnDisable()
    {
        _enemySpawner.Released -= Add;
    }

    public void Add()
    {
        _count++;
        Changed?.Invoke(_count);
    }

    public void Reset()
    {
        _count = StartCount;
        Changed?.Invoke(_count);
    }
}
