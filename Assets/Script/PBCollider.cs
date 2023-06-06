using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Enemy‚ÆPlayer‚Ì’e‚Ì“–‚½‚è”»’è </summary>
public class PBCollider : MonoBehaviour
{
    Vector3 _bScale = default;
    Rect rect = default;
    bool _isHit = default;
    bool _canHit = default;

    private void Start()
    {
        _bScale = transform.localScale;
        _canHit = true;
    }
    private void Update()
    {
        var temp = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemies = new List<GameObject>(temp);
        foreach (var enemy in enemies)
        {
            if (enemy)
            {
                rect = new Rect(transform.position, _bScale);
                Rect enemyRect = new Rect(enemy.transform.position, enemy.transform.localScale);

                if (_canHit)
                {
                    _isHit = JudgeHit(enemyRect, rect);
                    if (_isHit)
                    {
                        _canHit = false;
                        enemy.GetComponent<EnemyHP>().Damaged();
                        Destroy(gameObject);
                    }
                }

            }
        }
    }

    bool JudgeHit(Rect enemy, Rect pBullet)
    {
        if (pBullet.xMax < enemy.xMin) return false;
        if (enemy.xMax < pBullet.xMin) return false;

        if (pBullet.yMax < enemy.yMin) return false;
        if (enemy.yMax < pBullet.yMin) return false;

        return true;
    }
}
