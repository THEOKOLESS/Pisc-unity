using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class Footman : MonoBehaviour
    {
        [SerializeField] private GameObject selectedRing;
        private PlayerController movePos;
        
        public Attack attack;

        private void Awake()
        {
            movePos = GetComponent<PlayerController>();
            SetSelectedVisible(false);
           
        }

        private void OnEnable()
        {
            attack.OnAttack += OnAttackLithener;
            MoveTo(new Vector3(-3.7f, -0.9f, 0));
        }

        private void OnDisable()
        {
            attack.OnAttack -= OnAttackLithener;
        }

        void OnAttackLithener()
        {
            Debug.Log(transform.position);
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

