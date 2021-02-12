﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{

    public class Attack : MonoBehaviour
    {
        public static Attack instance { get; private set; } // singleton
        public delegate void VoidDelegate();

        public event VoidDelegate OnAttack; //follow

        public delegate void VoidDelegateInt(Collider2D i);

        public event VoidDelegateInt GetAttacked; // take damage

        public void RaiseGetAttacked(Collider2D val)
        {
            GetAttacked?.Invoke(val);
        }

        private void Awake()
        {
            Debug.Log("AWAKE P  UTAIN");
            if (instance == null)
                instance = this;
        }

        private void Update()
        { 
            OnAttack();  
        }

        public override string ToString()
        {
            return  ("coucou");
        }
    }
}
