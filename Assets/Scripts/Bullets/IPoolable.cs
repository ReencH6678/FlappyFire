using UnityEngine.Events;
public interface IPoolable
{
    public event UnityAction<IPoolable> DeactivationRequested;
    public void ResetObject() { }
}
