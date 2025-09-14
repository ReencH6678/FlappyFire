using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private BoxCollider2D _spawnBox;
    [SerializeField] private Score _score;

    [SerializeField] protected float _spawnRate;

    private Coroutine _spawnCorutine;

    private bool _isOn = true;

    public override void ActionOnGet(Enemy obj)
    {
        obj.Defeated += _score.Add;
        obj.SetBulletSpawner(_bulletSpawner);
        obj.SetScore(_score);
        base.ActionOnGet(obj);
    }

    public override void Release(IPoolable obj)
    {
        base.Release(obj);
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
