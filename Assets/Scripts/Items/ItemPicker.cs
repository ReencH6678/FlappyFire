using UnityEngine;

[RequireComponent(typeof(Health))]
public class ItemPicker : MonoBehaviour, IItemVisitor
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();    
    }

    public void VisitAidBox(AidBox aidBox, float count)
    {
        _health.Heal(count);
        Destroy(aidBox.gameObject);
    }
}
