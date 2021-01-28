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
    private float normX;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerController coucou;
        //Debug.Log(coucou);
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
            normX = _moveDirNomalized.x;
            dir = Mathf.Clamp(normX, minY, maxY);
            animator.SetFloat("dirY", _moveDir.y);
            animator.SetFloat("dirX", _moveDir.x);

            if (_moveDirNomalized.y >= 0.1 && dir == normX)
            {
                SetDirection("moving_up_right");
                transform.eulerAngles = new Vector2(0, 0);
            }
            else if (_moveDirNomalized.y >= 0.1 && Mathf.Clamp(Mathf.Abs(normX), minY, maxY) == Mathf.Abs(normX))
            {
                SetDirection("moving_up_right");
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (_moveDirNomalized.y <=  -0.1 && dir == normX)
            {
                SetDirection("moving_down_right");
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (_moveDirNomalized.y <= -0.1 && Mathf.Clamp(normX, Mathf.Abs(maxY), Mathf.Abs(minY)) == normX)
            {
                SetDirection("moving_down_right");
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
            //Debug.Log(Mathf.Clamp(normX, Mathf.Abs(minY), Mathf.Abs(maxY)));


            // Debug.Log("var = " + normX);
            //  Debug.Log("minY = " + Mathf.Abs(minY));
            // Debug.Log("maxY = " + Mathf.Abs(maxY));
            //Debug.Log("Mathf.Clamp(normX, Mathf.Abs(minY), Mathf.Abs(maxY)) " + Mathf.Clamp(normX, Mathf.Abs(minY), Mathf.Abs(maxY)));

            Debug.Log(_moveDirNomalized);
            animator.SetBool("moving", true);
        }
        else
            SetDirection("stop");
    }

     public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        this.distX = movePosition.x - transform.position.x;
        this.distY = movePosition.y - transform.position.y;
    }

    public  void SetDirection(string dir) {

        animator.SetBool("moving_up", false);
        animator.SetBool("moving_up_right", false);
        animator.SetBool("moving_up_left", false);

        animator.SetBool("moving_right", false);
        animator.SetBool("moving_left", false);

        animator.SetBool("moving_down", false);
        animator.SetBool("moving_down_right", false);
        animator.SetBool("moving_down_left", false);


        switch (dir)
        {
            case "moving_up":
                animator.SetBool("moving_up", true);
                break;
            case "moving_up_right":
                animator.SetBool("moving_up_right", true);
                break;
            case "moving_up_left":
                animator.SetBool("moving_up_left", true);
                break;
            case "moving_right":
                animator.SetBool("moving_right", true);
                break;
            case "moving_left":
                animator.SetBool("moving_left", true);
                break;
            case "moving_down":
                animator.SetBool("moving_down", true);
                break;
            case "moving_down_right":
                animator.SetBool("moving_down_right", true);
                break;
            case "moving_down_left":
                animator.SetBool("moving_down_left", true);
                break;
            case "stop":
                animator.SetBool("moving", false);
                break;
            default:
                break;
        }


    }

    public void FlipHorizontal()
    {
        animator.transform.Rotate(0, 180, 0);
    }

}
