using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _attackTime;
    [SerializeField] private Transform _bulletSpawnPoint;

    private BulletSpawner _spawner;

    private bool _canAttack = true;
    private Coroutine _attackCorutine;

    public bool CanAttack => _canAttack;

    private void OnEnable()
    {
        _canAttack = true;
    }

    public void Attack(BulletSpawner bulletSpawner)
    {
        _spawner = bulletSpawner;

        if (_attackCorutine == null)
            _attackCorutine = StartCoroutine(SpawnBullet());
        else
            _attackCorutine = null;

    }

    public IEnumerator SpawnBullet()
    {
        var waitForSeconds = new WaitForSeconds(_attackTime);

        if (_canAttack)
        {
            _spawner.Spawn(_bulletSpawnPoint, _bullet);
            _canAttack = false;
        }

        yield return waitForSeconds;

        _canAttack = true;
        _attackCorutine = null;
    }
}
