using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _speed = 0.1f;

    public enum BulletType
    {
        None,
        Player,
        Enemy,
    }

    [SerializeField]private BulletType _bType = BulletType.None;
    public BulletType ThisBulletType { get => _bType; set => _bType = value; }

    // Start is called before the first frame update
    void Start()
    {
        //Action<Vector2> bangAction = Bang;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_bType)
        {
            case BulletType.Player: Bang(Vector2.right); break;
            case BulletType.Enemy: Bang(Vector2.left); break;
            default: break;
        }

    }

    public void Bang(Vector2 direction)
    {
        transform.Translate(direction * _speed);
    }
}
