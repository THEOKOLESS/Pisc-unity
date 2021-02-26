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
        private Collider2D orcForum;
        private Vector3 _aIPos;
        private Vector3 _enemyPos;
        private float _distBetweenTarget;
        [HideInInspector] public float timing;
        public bool isOnTarget;

        public static Orc instance { get; private set; } // singleton
        [HideInInspector] public bool    isForumAttacked; 

        [SerializeField] private GameObject aggroRange;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
            if (instance == null)
                instance = this;
        }


        private void OnEnable()
        {
            // Attack.instance.AiAttackForum += Instance_AiForumAttAcked;
             GetAttacked.instance.OnTownAttack += Instance_AiForumAttAcked;

            humanForum = FootmanForum.instance.GetComponent<Collider2D>();
            orcForum = OrcForum.instance.GetComponent<Collider2D>(); 
            timing = 0f;
            isOnTarget = false;
            isForumAttacked = false;
        }

        // private void Instance_AiForumAttAcked(Collider2D target)
        // {
        //     if(target){
        //         Vector3 aIPos = transform.position;
        //         Vector3 enemyPos = target.transform.position;
        //         float distBetweenTarget = Vector3.Distance(aIPos, enemyPos);
        //         if (distBetweenTarget > 2f)
        //         {
        //             MoveTo(enemyPos);
        //         }
        //         else 
        //             isOnTarget = false;
        //     }
        // }

        private void Instance_AiForumAttAcked(bool isIt)
        {
            Vector3 aIPos = transform.position;
            Vector3 forumPos = orcForum.transform.position;
            float distBetweenTarget = Vector3.Distance(aIPos, forumPos);
            if(isIt == true){
                Debug.Log("forum attacked");
                
                isOnTarget = false;
                if (distBetweenTarget > 3f){
                    GetComponent<PlayerController>().IsAttacking(false);
                    MoveTo(Vector3.Lerp(aIPos, forumPos, 0.9f)); 
                    isForumAttacked = true; 
                }
                else
                {
                    isForumAttacked = false; 
                }
                 
            }
            else if (isIt == false)
            {
                Debug.Log("forum safe");
                isOnTarget = false;
                isForumAttacked = false;
                enemy = humanForum;
            }
        }

        private void OnDisable()
        {
            // Attack.instance.AiAttackForum -= Instance_AiForumAttAcked;
              GetAttacked.instance.OnTownAttack -= Instance_AiForumAttAcked;
        }

        private void Update()
        {
            if (humanForum != null)
            {
                // if (isForumAttacked == true){
                //     GetComponent<PlayerController>().IsAttacking(false);
                //     isOnTarget = true;
                //     Attack.instance.RaiseAiAttackForum(orcForum);
                // }
                /*else*/ 
                if (enemy != null && isForumAttacked == false)
                     Ft_Attack();
                else {
                    isOnTarget = false;
                    enemy = humanForum;
                    GetComponent<PlayerController>().IsAttacking(false);
                }
            }
            else
                GetComponent<PlayerController>().IsAttacking(false);
        }

        public void SetEnemy(Collider2D enemy)
        {
            this.enemy = enemy;
            isOnTarget = true;
        }


        public void IsForumAttacked(bool isIt)
        {
            this.isForumAttacked = isIt;
            isOnTarget = true;
        }

        private void    Ft_Attack(){
            _aIPos = transform.position;
            _enemyPos = enemy.transform.position;
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

        public void MoveTo(Vector3 targetPos)
        {
            movePos.SetMovePosition(targetPos);
        }

          public  void DeleteFromList(){
            Debug.Log("orc just Died");
            OrcForum.instance.orcList.Remove(this);
        }
    }   
}

