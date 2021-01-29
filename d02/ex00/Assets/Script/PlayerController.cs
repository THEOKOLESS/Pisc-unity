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

    private Vector3 _moveDirNomalized;

    private float minY;
    private float maxY;
    private float dir;
    private float _xDirNormalized;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 2f;
        movePosition = transform.position;
    }

    public override string ToString()
    {
        return "speed ; " + _speed ;
    }

    // Update is called once per frame
    void Update()
    {

        _moveDir = (movePosition - transform.position);


        if (_moveDir.magnitude > 0.1f)
        {
            _moveDirNomalized = _moveDir.normalized;
            minY = _moveDirNomalized.y - 0.4f;
            maxY = _moveDirNomalized.y + 0.4f;
            _xDirNormalized = _moveDirNomalized.x;
            dir = Mathf.Clamp(_xDirNormalized, minY, maxY);

            if (_moveDirNomalized.y >= 0.1 && dir == _xDirNormalized)
            {
                SetDirection("moving_up_side");
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (_moveDirNomalized.y >= 0.1 && Mathf.Clamp(Mathf.Abs(_xDirNormalized), minY, maxY) == Mathf.Abs(_xDirNormalized))
            {
                SetDirection("moving_up_side");
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (_moveDirNomalized.y <=  -0.1 && dir == _xDirNormalized)
            {
                SetDirection("moving_down_side");
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (_moveDirNomalized.y <= -0.1 && Mathf.Clamp(_xDirNormalized, Mathf.Abs(maxY), Mathf.Abs(minY)) == _xDirNormalized)
            {
                SetDirection("moving_down_side");
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (_moveDirNomalized.y >= 0.4 && _moveDirNomalized.y > _moveDirNomalized.x)
            {
                SetDirection("moving_up");
            }
            else if (_moveDirNomalized.y <= -0.4 && _moveDirNomalized.y < _moveDirNomalized.x)
            {
                SetDirection("moving_down");
            }
            else if (_moveDirNomalized.x >= 0.4 && _moveDirNomalized.x > _moveDirNomalized.y)
            {
                SetDirection("moving_right");
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (_moveDirNomalized.x <= -0.4 && _moveDirNomalized.x < _moveDirNomalized.y)
            {
                SetDirection("moving_left");
                transform.eulerAngles = new Vector2(0, 180);
            }

            transform.position += _moveDir.normalized * _speed * Time.deltaTime;
            animator.SetBool("moving", true);
        }
        else
            SetDirection("stop");
    }

     public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }

    public  void SetDirection(string dir) {

        animator.SetBool("moving_up", false);
        animator.SetBool("moving_up_side", false);

        animator.SetBool("moving_side", false);

        animator.SetBool("moving_down", false);
        animator.SetBool("moving_down_side", false);


        switch (dir)
        {
            case "moving_up":
                animator.SetBool("moving_up", true);
                break;
            case "moving_up_side":
                animator.SetBool("moving_up_side", true);
                break;
            case "moving_right":
                animator.SetBool("moving_side", true);
                break;
            case "moving_left":
                animator.SetBool("moving_side", true);
                break;
            case "moving_down":
                animator.SetBool("moving_down", true);
                break;
            case "moving_down_side":
                animator.SetBool("moving_down_side", true);
                break;
            case "stop":
                animator.SetBool("moving", false);
                break;
            default:
                break;
        }


    }

}
