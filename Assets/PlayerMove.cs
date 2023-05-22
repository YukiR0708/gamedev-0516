using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //¶‰EˆÚ“®
        float hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * hInput * _speed);
        //ƒWƒƒƒ“ƒv
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    void Jump()
    {
        for(float theta = 0f; theta <= Mathf.PI; theta += (Mathf.PI / 180))
        {
            transform.Translate(Vector2.up * Mathf.Sin(theta));
        }
    }
}
