using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    BulletMove _bm = default;
    GameObject _player = default;
    Rect _playerRect = default;
    bool _isHit = default;
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
        rect = new Rect(transform.position, _bScale);
        if (_bm.ThisBulletType == BulletMove.BulletType.Enemy)
        {
            _playerRect = new Rect(_player.transform.position, _pScale);
            _isHit = JudgeHit(_playerRect, rect);
            if (_isHit)
            {
                _playerHP.Damaged();
                Destroy(gameObject);
            }

        }
        else if (_bm.ThisBulletType == BulletMove.BulletType.Player)
        {
            var temp = GameObject.FindGameObjectsWithTag("Enemy");
            List<GameObject> enemies = new List<GameObject>(temp);
            foreach (var enemy in enemies)
            {
                if (enemy)
                {
                    Rect enemyRect = new Rect(enemy.transform.position, enemy.transform.localScale);
                    {
                        _isHit = JudgeHit(enemyRect, rect);
                        if (_isHit)
                        {
                            enemy.GetComponent<EnemyHP>().Damaged();
                            Destroy(gameObject);
                        }
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
