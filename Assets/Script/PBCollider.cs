using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Enemy‚ÆPlayer‚Ì’e‚Ì“–‚½‚è”»’è </summary>
public class PBCollider : MonoBehaviour
{
    GameObject[] enemies = new GameObject[5];
    Vector3 _bScale = default;
    Rect rect = default;


    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _bScale = transform.localScale;
    }
    private void Update()
    {
        foreach (var enemy in enemies)
        {
            rect = new Rect(transform.position, _bScale);
            Rect enemyRect = new Rect(enemy.transform.position, enemy.transform.localScale);
            //Debug.Log($"{rect}, {enemyRect}");
            bool _isHit = JudgeHit(enemyRect, rect);
            if (_isHit)
            {
                enemy.GetComponent<EnemyHP>().Damaged();
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
