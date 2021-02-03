using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMove : MonoBehaviour
{
    private Vector3 _movePos;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 2f;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position += _movePos * _speed * Time.deltaTime;
    }

    public void SetMovePos(Vector3 _movePos)
    {
        this._movePos = _movePos;
    }
}
    