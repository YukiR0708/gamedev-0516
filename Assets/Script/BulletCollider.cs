using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    BulletMove _bm = default;
    GameObject _player = default;
    Rect _playerRect = default;
    Rect rect = default;
    Vector3 _pScale = default;
    Vector3 _bScale = default;
    PlayerHP _playerHP = default;

    void Start()
    {
        _bm = gameObject.GetComponent<BulletMove>();

        if (_bm.ThisBulletType == BulletMove.BulletType.Enemy)
        {
            _player = GameObject.FindWithTag("Player");
            _pScale = _player.transform.localScale;
            _playerHP = _player.GetComponent<PlayerHP>();
        }
        else if (_bm.ThisBulletType == BulletMove.BulletType.Player)
        {

        }

        _bScale = transform.localScale;

    }

    void Update()
    {
        var temp = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemies = new List<GameObject>(temp);
        rect = new Rect(transform.position, _bScale);
        if (_bm.ThisBulletType == BulletMove.BulletType.Enemy)
        {
            _playerRect = new Rect(_player.transform.position, _pScale);
            var isHit = JudgeHit(_playerRect, rect);
            if (isHit)
            {
                _playerHP.Damaged();
                Destroy(gameObject);
            }

        }
        else if (_bm.ThisBulletType == BulletMove.BulletType.Player)
        {
            foreach (var enemy in enemies)
            {
                if (enemy)
                {
                    var enemyRect = new Rect(enemy.transform.position, enemy.transform.localScale);
                    var isHit = JudgeHit(enemyRect, rect);
                    if (isHit)
                    {
                        enemy.GetComponent<EnemyHP>().Damaged(1);
                        Destroy(gameObject);
                    }
                }
            }

        }
        else if (_bm.ThisBulletType == BulletMove.BulletType.Razer)
        {
            foreach (var enemy in enemies)
            {
                if (enemy)
                {
                    var enemyRect = new Rect(enemy.transform.position, enemy.transform.localScale);
                    var isHit = JudgeHit(enemyRect, rect);
                        if (isHit)
                        {
                            enemy.GetComponent<EnemyHP>().Damaged(3);
                            Destroy(gameObject);
                        }
                }
            }
            var temp2 = GameObject.FindGameObjectsWithTag("EnemyBullet");
            List<GameObject> eBullets = new List<GameObject>(temp2);
            foreach (var eb in eBullets)
            {
                var ebRect = new Rect(eb.transform.position, eb.transform.localScale);
                {
                    var isHit = JudgeHit(ebRect, rect);
                    if (isHit)
                    {
                        Destroy(eb);
                    }
                }
            }
        }
    }

    bool JudgeHit(Rect target, Rect bullet)
    {
        if (bullet.xMax < target.xMin) return false;
        if (target.xMax < bullet.xMin) return false;

        if (bullet.yMax < target.yMin) return false;
        if (target.yMax < bullet.yMin) return false;

        return true;
    }

}
