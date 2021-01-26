using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private Vector3 movePosition;
    private Vector3 _moveDir;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 2f;
        movePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = (movePosition - transform.position);
        if (_moveDir.magnitude > 0.01f)
            transform.position += _moveDir.normalized * _speed * Time.deltaTime;
    }
    public  void    SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }
}
