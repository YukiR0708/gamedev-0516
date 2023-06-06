using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed = 0.1f;
    [SerializeField] float _jumpTime = 0f;
    [SerializeField] float _jumpHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ç∂âEà⁄ìÆ
        float hInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * hInput * _speed);
        //ÉWÉÉÉìÉv
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }

    }
    IEnumerator Jump()
    {
        Vector2 dir = new Vector2(transform.position.x, transform.position.y + _jumpHeight);
        Vector2 initialPos = transform.position;
        transform.position = Vector2.Lerp(transform.position, dir, _jumpTime / 2);
        yield return new WaitForSeconds(_jumpTime / 2);
        transform.position = Vector2.Lerp(transform.position, initialPos, _jumpTime / 2);
    }
}
