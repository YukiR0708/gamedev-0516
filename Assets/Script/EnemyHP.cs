using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    [SerializeField] int _eHP = 3;

    void Update()
    {
        if(_eHP == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damaged()
    {
        if (0 < _eHP)
        {
            _eHP--;
        }
    }
}
