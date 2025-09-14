using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const int StartCount = 0;

    private int _count;

    public event UnityAction<int> Changed;

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
