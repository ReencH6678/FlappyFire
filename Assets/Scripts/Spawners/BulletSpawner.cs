using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner<BulletObject>
{
    private Vector3 _spawnPosition;
    private Bullet _bullet;
    public void Spawn(Transform spawnPosition, Bullet bullet)
    {
        _bullet = bullet;
        _spawnPosition = spawnPosition.position;
        _pool.Get();
    }

    public override void ActionOnGet(BulletObject obj)
    {
        base.ActionOnGet(obj);
        obj.SetBullet(_bullet);
    }
    protected override Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
}
