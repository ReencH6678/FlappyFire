using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] private List<T> _prefabes;

    public ObjectPool<T> _pool;

    private List<T> _activeObjects = new List<T>();
    private int _poolCapacity = 100;
    private int _poolMaxSize = 100;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (
                createFunc: () => CreateFunc(),
                actionOnGet: (obj) => ActionOnGet(obj),
                actionOnRelease: (obj) => obj.gameObject.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize);
    }

    private T CreateFunc()
    {
        T prefabe = _prefabes[Random.Range(0, _prefabes.Count)];
        return Instantiate(prefabe, GetSpawnPosition(), prefabe.transform.rotation);
    }

    public void Reset()
    {
        foreach (T obj in _activeObjects)
                _pool.Release(obj);

        _activeObjects.Clear();
        _pool.Clear();
    }

    public virtual void ActionOnGet(T obj)
    {
        obj.transform.position = GetSpawnPosition();
        obj.gameObject.SetActive(true);
        obj.DeactivationRequested += Release;
        _activeObjects.Add(obj);
    }

    public virtual void Release(IPoolable obj)
    {
        _pool.Release((T)obj);
        _activeObjects.Remove((T)obj);
        obj.DeactivationRequested -= Release;
    }

    protected virtual Vector3 GetSpawnPosition()
    {
        return new Vector3(0, 0, 0);
    }
}