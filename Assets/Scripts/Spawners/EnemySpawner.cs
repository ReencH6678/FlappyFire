using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private BoxCollider2D _spawnBox;

    [SerializeField] protected float _spawnRate;

    private Coroutine _spawnCorutine;

    private bool _isOn = true;

    public event UnityAction Released;
    public override void ActionOnGet(Enemy obj)
    {
        obj.SetBulletSpawner(_bulletSpawner);
        base.ActionOnGet(obj);
    }

    public override void Release(IPoolable obj)
    {
        base.Release(obj);
        Released?.Invoke();
    }
    public void StartSpawn()
    {
        if (_spawnCorutine == null)
                _spawnCorutine = StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_spawnRate);
        _isOn = true;

        while (_isOn)
        {
            _pool.Get();
            yield return waitForSeconds;
        }
    }
    public void OffSpawn()
    {
        _isOn = false;

        if( _spawnCorutine != null)
        {
            StopCoroutine(_spawnCorutine);
            _spawnCorutine = null;
        }
    }

    protected override Vector3 GetSpawnPosition()
    {
        Bounds bounds = _spawnBox.bounds;

        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
    }
}
