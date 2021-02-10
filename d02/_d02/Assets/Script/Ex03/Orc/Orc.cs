using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class Orc : MonoBehaviour
    {
        private PlayerController movePos;
        public Vector3 posOrc;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
        }


        private void OnEnable()
        {
            MoveTo(new Vector3(6.7f, -7f, 0));
        }
        private void Update()
        {
            posOrc = transform.position;
           // Debug.Log(posOrc);
        }

            public void MoveTo(Vector3 targetPos)
        {
            movePos.SetMovePosition(targetPos);
        }
    }   
}

