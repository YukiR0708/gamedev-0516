using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _borderDistance = Screen.width / 2;
    GameObject _player = default;
    [SerializeField] GameObject _bullet;
    bool _canShoot = true;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        //Player‚Æ‚Ì‹——£
        var distance = Vector2.Distance(_player.transform.position, this.gameObject.transform.position);
        if(distance < _borderDistance && _canShoot)
        {
            _canShoot = false;
            StartCoroutine(ShootCor());
        }
    }

    IEnumerator ShootCor()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(1.0f);
        _canShoot = true;
    }
}
