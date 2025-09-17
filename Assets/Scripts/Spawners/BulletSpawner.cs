using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private Quaternion _bulletDirection;

    private Vector3 _spawnPosition;
    private BulletData _bullet;

    public void Spawn(Transform spawnPosition, BulletData bullet)
    {
        _bullet = bullet;
        _spawnPosition = spawnPosition.position;
        _pool.Get();
    }

    public override void ActionOnGet(Bullet obj)
    {
        base.ActionOnGet(obj);
        obj.SetBullet(_bullet);
        obj.SetDirection(_bulletDirection);
    }
    protected override Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
}
