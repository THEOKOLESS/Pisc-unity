﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class Orc : MonoBehaviour
    {
        private PlayerController movePos;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
        }

        private void OnEnable()
        {
            MoveTo(new Vector3(6.7f, -10f, 0));
        }

        public void MoveTo(Vector3 targetPos)
        {
            movePos.SetMovePosition(targetPos);
        }
    }   
}

