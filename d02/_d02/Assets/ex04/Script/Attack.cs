using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{

    public class Attack : MonoBehaviour
    {
        public static Attack instance { get; private set; } // singleton
        public delegate void VoidDelegate();

        public event VoidDelegate OnAttack; //follow

        public delegate void VoidDelegateCollider2D(Collider2D i);

        public event VoidDelegateCollider2D GetAttacked; // take damage

        public event VoidDelegateCollider2D AiAttackForum;

        public void RaiseGetAttacked(Collider2D val)
        {
            GetAttacked?.Invoke(val);
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Update()
        { 
            OnAttack();  
        }
    }
}
