using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health health))
        {
            if(collision.TryGetComponent<Player>(out _))
            {
                health.Kill(); 
            }
        }
    }
}
