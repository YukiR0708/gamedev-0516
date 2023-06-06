using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject _bullet = default;
    [SerializeField] GameObject _razer = default;
   [SerializeField] float _razerTime = 0.2f;
    GameObject _nowRazer = default;
    bool _canShoot = default;
    float _holdTime = 0f;
    float _oldTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Z) && _canShoot)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
        }
        else if(Input.GetKey(KeyCode.Z))
        {
            _holdTime += Time.deltaTime;
        }

        if(1.0f < _holdTime && _oldTime < 1.0f)
        {
            _canShoot = false;
            _nowRazer =  Instantiate(_razer, transform.position, transform.rotation) as GameObject;
            _holdTime = 0f;
            StartCoroutine(RazerCor());
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            _holdTime = 0f;
        }
        _oldTime = _holdTime;
    }

    IEnumerator RazerCor()
    {
        yield return new WaitForSeconds(_razerTime);
        Destroy(_nowRazer);
        _canShoot = true;
    }
}
