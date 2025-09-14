using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Entity : MonoBehaviour
{
    public abstract void Die();
    public abstract void Life();
    public bool IsDead { get; protected set; }
}
