using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class Footman : MonoBehaviour
    {
        [SerializeField] private GameObject selectedRing;
        private PlayerController movePos;

        public static Footman  instance {get; private set;}
        private bool goAttack;
        private Collider2D enemy;
        private float distBetweenTarget;

        private Vector3 footmanPos;
        private Vector3 enemyPos;
        [HideInInspector]public float timing = 0f;



        private void Awake()
        {
            goAttack = false;
            movePos = GetComponent<PlayerController>();
            SetSelectedVisible(false);    
            if (instance == null)
                instance = this;
        }

        private void OnEnable()
        {
            MoveTo(new Vector3(-0.5f, 1f, 0));
            timing = 0f;
        }

        private void OnDisable()
        {
            // SelectionController.instance.footmanSelectedList.Remove(this);
        }

        private void Update()
        {
            if (goAttack == true)
            {
                if (enemy != null)
                {
                    footmanPos = transform.position;
                    enemyPos = enemy.transform.position;
                    distBetweenTarget = Vector3.Distance(footmanPos, enemyPos);
                    if (distBetweenTarget < 0.8)
                    {
                        Vector3 enemySide = Vector3.Lerp(footmanPos, enemyPos, 0.1f);
                        MoveTo(enemySide);
                        timing += Time.deltaTime;
                       
                        GetComponent<PlayerController>().IsAttacking(true);
                        if (timing >= 1f && enemy != null)
                        {
                            timing = 0f;
                            Attack.instance.RaiseGetAttacked(enemy);
                        }
                    }
                    else
                    {
                        MoveTo(enemyPos);
                        timing = 0f;
                        GetComponent<PlayerController>().IsAttacking(false);
                    }

                }
                else
                {
                    goAttack = false;
                    GetComponent<PlayerController>().IsAttacking(false);
                }
            }
            else
                GetComponent<PlayerController>().IsAttacking(false);

        }
        public  void DeleteFromSelection(){
            SelectionController.instance.footmanSelectedList.Remove(this);
            Destroy(this);
        }

        public  void    SetAttack(bool goAttack)
        {
            this.goAttack = goAttack;
        }

        public void SetEnemy(Collider2D enemy)
        {
            this.enemy = enemy;
        }

        public void SetSelectedVisible(bool visible)
        {
            selectedRing.SetActive(visible);
        }

        public void MoveTo(Vector3 targetPos)
        {
            movePos.SetMovePosition(targetPos);
        }
    }
}

