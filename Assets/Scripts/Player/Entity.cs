using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Entity : MonoBehaviour
{
    public abstract void Die();
    public abstract void Live();
    public bool IsDead { get; protected set; }
}
