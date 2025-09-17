using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(float direction)
    {
        transform.Translate(new Vector3(direction * _speed * Time.deltaTime, 0));
    }

    public void SetSpeed(float speed)
    {
        if (speed > 0)
            _speed = speed;
    }
}
