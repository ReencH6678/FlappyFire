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
        if (Random.Range(0, 100) < _dropChoice)
            Instantiate(_item, transform.position, Quaternion.identity);
    }
}
