using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Player‚ÆEnemy‚Ì’e‚Ì“–‚½‚è”»’è </summary>
public class EBCollider : MonoBehaviour
{
    GameObject _player = default;
    Rect _playerRect = default;
    bool _isHit = default;
    Rect rect = default;
    Vector3 _pScale = default;
    Vector3 _bScale = default;
    PlayerHP _playerHP = default;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _pScale = _player.transform.localScale;
        _bScale = transform.localScale;
        _playerHP = _player.GetComponent<PlayerHP>();
    }
    private void Update()
    {
        _playerRect = new Rect(_player.transform.position, _pScale);
        rect = new Rect(transform.position, _bScale);

        _isHit = isHit(_playerRect,  rect);
        if (_isHit)
        {
            _playerHP.Damaged();
            Destroy(gameObject);
        }
    }
    bool isHit(Rect player, Rect eBullet)
    {
        if (eBullet.xMax < player.xMin) return false;
        if (player.xMax < eBullet.xMin) return false;

        if (eBullet.yMax < player.yMin) return false;
        if (player.yMax < eBullet.yMin) return false;

        return true;
    }
}
