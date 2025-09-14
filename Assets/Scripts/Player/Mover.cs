using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private static bool _canMove = true;

    public void Move(float direction)
    {
        if (_canMove)
            transform.Translate(new Vector3(direction * _speed * Time.fixedDeltaTime, 0));
    }

    public void SetSpeed(float speed)
    {
        if (speed > 0)
            _speed = speed;
    }

    public static void Switch()
    {
        _canMove = !_canMove;
    }
}
