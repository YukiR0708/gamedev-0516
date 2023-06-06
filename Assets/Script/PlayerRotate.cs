using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    Vector2 _mousePos = default;
    float _pRotate = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        float y = Mathf.Abs(_mousePos.y - transform.position.y );
        float x = Mathf.Abs(_mousePos.x - transform.position.x);
        _pRotate = Mathf.Atan2(y, x);
       transform.rotation =  Quaternion.AngleAxis(_pRotate * 180 / Mathf.PI, new Vector3(0, 0, 1));
    }
}
