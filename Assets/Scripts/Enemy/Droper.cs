using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Droper : MonoBehaviour
{
    [SerializeField] private float _dropChoice;
    [SerializeField] private Item _item;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Drop;
    }

    private void OnDisable()
    {
        _health.Died -= Drop;
    }

    private void Drop()
    {
        float maxPercent = 100;
        float minPercent = 0;
        if (Random.Range(minPercent, maxPercent) < _dropChoice)
            Instantiate(_item, transform.position, Quaternion.identity);
    }
}
