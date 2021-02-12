﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class Footman : MonoBehaviour
    {
        [SerializeField] private GameObject selectedRing;
        private PlayerController movePos;

    
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
            MoveTo(new Vector3(-3.7f, -0.9f, 0));
        }   

        private void Update()
        {
            if (goAttack == true)
            {
                if (enemy != null )
                {
                    footmanPos = transform.position;
                    enemyPos = enemy.transform.position;
                    distBetweenTarget = Vector3.Distance(footmanPos, enemyPos);
                    MoveTo(enemyPos);
                    //Debug.Log(enemy);
                    if (distBetweenTarget < 0.8)
                    {
                        Vector3 enemySide = Vector3.Lerp(footmanPos, enemyPos, 0.2f);
                        MoveTo(enemySide);
                        if (timing > 3f && enemy != null)
                        {
                            timing = 0f;
                            Attack.instance.RaiseGetAttacked(enemy);
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

