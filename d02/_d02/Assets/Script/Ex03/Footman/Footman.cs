    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class Footman : MonoBehaviour
    {
        [SerializeField] private GameObject selectedRing;
        private PlayerController movePos;

        public FootmanAttack attack;
        private bool goAttack;
        private Collider2D enemy;
        private float distBetweenTarget;

        private Vector3 footmanPos;
        private Vector3 enemyPos;
        private float timing;

        private void Awake()
        {
            goAttack = false;
            movePos = GetComponent<PlayerController>();
            SetSelectedVisible(false);          
        }

        private void OnEnable()
        {
            attack.OnAttack2 += OnAttackLithener;
            MoveTo(new Vector3(-3.7f, -0.9f, 0));
        }   

        private void OnDisable()
        {
            attack.OnAttack2 -= OnAttackLithener;
        }

        void OnAttackLithener(GameObject test)
        {
           // if(test != null)
                Debug.Log(test);
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
                    MoveTo(enemyPos);
                    if (distBetweenTarget < 0.8)
                    {
                        Vector3 enemySide = Vector3.Lerp(footmanPos, enemyPos, 0.2f);
                        MoveTo(enemySide);
                        if (enemy.GetComponent<GetAttacked>().HP > 0)
                        {
                            enemy.GetComponent<GetAttacked>().SetAttack(true);
                            if (timing > 3f)
                            {
                                timing = 0f;
                                Attack.instance.RaiseGetAttacked(10);
                            }
                        }
                        else
                        {
                            enemy.GetComponent<GetAttacked>().SetAttack(false);
                        }

                    }
                }
                else
                    goAttack = false;
            }
            timing += Time.deltaTime;
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

