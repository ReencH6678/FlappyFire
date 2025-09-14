using UnityEngine;

[RequireComponent(typeof(Mover))]
public class AidBox : MonoBehaviour, IItem
{
    [SerializeField] private float _healCount;
    private Mover _mover;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.Move(Vector2.left.x);
    }

    public void Pick(IItemVisitor visitor)
    {
        visitor.VisitAidBox(this, _healCount);
    }
}
