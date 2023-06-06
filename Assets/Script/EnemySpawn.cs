using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float _checkInterval = 0f;
    [SerializeField] GameObject _enemy = default;
    bool _canCheck = default;
    void Start()
    {
        _canCheck = true;
    }

    void Update()
    {
        if(_canCheck)
        {
            _canCheck = false;
            StartCoroutine(SpawnCheck());
        }
    }

    IEnumerator SpawnCheck()
    {
        if(transform.childCount == 0)
        {
            Instantiate(_enemy, gameObject.transform);
        }
        yield return new WaitForSeconds(_checkInterval);
        _canCheck = true;
    }
}
