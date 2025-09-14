using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    public void Jump(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, _jumpForce);
    }
}
