using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class GetAttacked : MonoBehaviour
    {
        [SerializeField] private int hp;
        public int HP
        {
            get
            {
                return hp;
            }
            private set
            {
                hp = value;
            }
        }
        private bool isAttacked;



        private void OnEnable()
        {
            Attack.instance.GetAttacked += Instance_GetAttacked;
        }

        private void OnDisable()
        {
            Attack.instance.GetAttacked -= Instance_GetAttacked;
        }

        private void Instance_GetAttacked(int i)
        {
            if (isAttacked == true)
            {
                HP -= i;
                Debug.Log("Orc Unit[{1} / 100]HP has been attacked." + HP);
            }
        }


        private void Update()
        {
            if (HP < 1)
            {
                Debug.Log("orc Died");
                HP = 0;
            }
        }

        public void SetAttack(bool isAttacked)
        {
            this.isAttacked = isAttacked;
        }

    }
}
