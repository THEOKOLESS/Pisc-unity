using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class Orc : MonoBehaviour
    {
        private PlayerController movePos;
        private Collider2D enemy;
        private Collider2D humanForum;
        private Vector3 _aIPos;
        private Vector3 _enemyPos;
        private float _distBetweenTarget;
        [HideInInspector] public float timing;
        public bool isOnTarget;

        [SerializeField] private GameObject aggroRange;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
        }


        private void OnEnable()
        {
            //MoveTo(new Vector3(Random.Range(-7f, 7f), Random.Range(-6f, 6f), 0));
            Attack.instance.AiAttackForum += Instance_AiAttackForum;
            humanForum = FootmanForum.instance.GetComponent<Collider2D>();
            enemy = humanForum;
            timing = 0f;
            isOnTarget = false;
        }

        private void Instance_AiAttackForum(Collider2D target)
        {
            if (target != null)
            {

                Vector3 aIPos = transform.position;
                Vector3 enemyPos = target.transform.position;
                float distBetweenTarget = Vector3.Distance(aIPos, enemyPos);
                if (distBetweenTarget < 0.8)
                {
                    Vector3 enemySide = Vector3.Lerp(aIPos, enemyPos, 0.1f);
                    MoveTo(enemySide);
                    Attack.instance.RaiseGetAttacked(target);
                }
                else
                {
                    MoveTo(enemyPos);
                }
                  
            }
        }

        private void OnDisable()
        {
            Attack.instance.AiAttackForum -= Instance_AiAttackForum;
        }

        private void Update()
        {
            if (humanForum != null)
            {
                if (enemy != null)
                {
                    _aIPos = transform.position;
                    _enemyPos = enemy.transform.position;
                    //Debug.LogFormat("enemy {0}, sa pos {1}",  enemy, _enemyPos);
                    _distBetweenTarget = Vector3.Distance(_aIPos, _enemyPos);
                    if (_distBetweenTarget < 0.8)
                    {
                        Vector3 enemySide = Vector3.Lerp(_aIPos, _enemyPos, 0.1f);
                        MoveTo(enemySide);
                        timing += Time.deltaTime;
                        GetComponent<PlayerController>().IsAttacking(true);
                        if (timing > 1f && enemy != null)
                        {
                            timing = 0f;
                            Attack.instance.RaiseGetAttacked(enemy);
                        }
                    }
                    else
                    {
                        MoveTo(_enemyPos);
                        timing = 0f;
                        GetComponent<PlayerController>().IsAttacking(false);
                    }
                      
                }
                else {
                    isOnTarget = false;
                    enemy = humanForum;
                    GetComponent<PlayerController>().IsAttacking(false);
                }
            }
            else
                GetComponent<PlayerController>().IsAttacking(false);
            //Instance_AiAttackForum(FootmanForum.instance.GetComponent<Collider2D>());

        }

        public void SetEnemy(Collider2D enemy)
        {
            this.enemy = enemy;
            isOnTarget = true;
        }

        public void MoveTo(Vector3 targetPos)
        {
            movePos.SetMovePosition(targetPos);
        }
    }   
}

