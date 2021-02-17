using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex02
{
    public class Footman : MonoBehaviour
    {
        [SerializeField] private GameObject selectedRing;
        private PlayerController movePos;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
            SetSelectedVisible(false);
           
        }

        private void OnEnable()
        {
            MoveTo(new Vector3(-3.7f, -0.9f, 0));
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

