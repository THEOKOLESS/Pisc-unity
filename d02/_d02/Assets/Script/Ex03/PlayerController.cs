using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ex03
{
    public class PlayerController : MonoBehaviour
    {
        private Vector3 movePosition;
        private Vector3 _moveDir;
        public Animator animator;

        private bool died = false;
        private bool attack = false;

        private Vector3 _moveDirNomalized;

        private float minY;
        private float maxY;
        private float dir;
        private float _xDirNormalized;

   

        // Update is called once per frame
        void Update()
        {
            if (died == false && attack == false)
            {
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
                else if (_moveDirNomalized.y <= -0.1 && dir == _xDirNormalized)
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

                animator.SetBool("moving", true);

                if (_moveDir.magnitude < 0.1f)
                {
                    _moveDirNomalized = Vector3.zero;
                    SetDirection("stop");
                }

                _moveDir = (movePosition - transform.position);
                GetComponent<SetMove>().SetMovePos(_moveDirNomalized);
            }
            else if (died == true)
            {
                GetComponent<SetMove>().SetMovePos(Vector3.zero);
                SetDirection("stop");
                animator.SetBool("dead", true);
            }
            else if (attack == true)
            {
                GetComponent<SetMove>().SetMovePos(Vector3.zero);
                SetDirection("stop");
                animator.SetBool("attack", true);
            }
        }

        public void SetMovePosition(Vector3 movePosition)
        {
            this.movePosition = movePosition;
            this._moveDir = (movePosition - transform.position);
            this._moveDirNomalized = this._moveDir.normalized;
            this.minY = this._moveDirNomalized.y - 0.4f;
            this.maxY = this._moveDirNomalized.y + 0.4f;
            this._xDirNormalized = this._moveDirNomalized.x;
            this.dir = Mathf.Clamp(this._xDirNormalized, this.minY, this.maxY);
        }

        public void IsDead(bool died)
        {
            this.died = died;
        }

        public  void IsAttacking(bool attack) 
        {
            this.attack = attack;
        }

        public void SetDirection(string dir)
        {

            animator.SetBool("moving_up", false);
            animator.SetBool("moving_up_side", false);

            animator.SetBool("moving_side", false);

            animator.SetBool("moving_down", false);
            animator.SetBool("moving_down_side", false);

            animator.SetBool("attack", false);


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
}
