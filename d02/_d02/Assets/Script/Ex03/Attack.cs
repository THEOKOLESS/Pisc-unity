using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{

    public class Attack : MonoBehaviour
    {
        public delegate void VoidDelegate();

        public static Attack instance { get; private set; }

        public event VoidDelegate OnAttack;

        public delegate void VoidDelegateInt(int i);

        public event VoidDelegateInt GetAttacked;

        public void RaiseGetAttacked(int val)
        {
            GetAttacked?.Invoke(val);
        }

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        { 
            OnAttack();  
        }
    }
}
