using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private Vector3 movePosition;
    private Vector3 _moveDir;
    public Animator animator;
    private float distX;
    private float distY;
    private float angle;

    private bool isMoving;
    private Vector3 _moveDirNomalized;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        _speed = 2f;
        movePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirNomalized = _moveDir.normalized;
        _moveDir = (movePosition - transform.position);
        if (_moveDir.magnitude > 0.01f)
        {
            //Debug.Log("distX -> " + distX);
            //Debug.Log("distY -> " + distY);
           // Debug.Log(angle);
            animator.SetFloat("dirY", _moveDir.y);
            //if(_moveDir.y > 0.1f && Mathf.Clamp(Mathf.Abs(_moveDir.normalized.x), 0.3f, 0.6f) == Mathf.Abs(_moveDir.normalized.x))
            // {
           // Debug.Log("x normal " + _moveDirNomalized.x);
           // Debug.Log("y normal " + _moveDirNomalized.y);
           // Debug.Log(Mathf.Clamp(_moveDirNomalized.x, _moveDirNomalized.y + 0.3f, _moveDirNomalized.y - 0.3f));
            if (_moveDirNomalized.y > 0.1 && Mathf.Clamp(_moveDirNomalized.x, _moveDirNomalized.y - 0.4f, _moveDirNomalized.y + 0.4f) == _moveDirNomalized.x)
                    Debug.Log("up right");
           // }
            animator.SetBool("moving", true);
            //Debug.Log(_moveDir.normalized);
            transform.position += _moveDir.normalized * _speed * Time.deltaTime;
        }
        else
            animator.SetBool("moving", false);
    }
    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        this.distX = movePosition.x - transform.position.x;
        this.distY = movePosition.y - transform.position.y;
        this.angle = Vector3.Angle(Vector3.up, movePosition);
    }
}
