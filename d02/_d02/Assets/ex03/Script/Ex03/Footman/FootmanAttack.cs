using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{

    public class FootmanAttack : MonoBehaviour
    {
 
        public delegate void VoidDelegateGameObject(GameObject gameobject);

        public event VoidDelegateGameObject OnAttack2;


        private Collider2D orc;

        private Vector3 worldPosition;


        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                worldPosition = worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0f;
                orc = Physics2D.OverlapPoint(worldPosition, LayerMask.GetMask("orc"));
               
                if (orc != null)
                {
                    Debug.Log("footmanAttack " + orc.gameObject);
                    OnAttack2(orc.gameObject);
                }
         
            }
        }
    }
}
