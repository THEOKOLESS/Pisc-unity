using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{ 
    public class Orc_aggro : MonoBehaviour
    {
        private GameObject orc;

        private void Awake()
        {
            orc = transform.parent.gameObject;
        }
        private void Update()
        {
            //Debug.Log(orc.GetComponent<Orc>().isOnTarget);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.layer != 6 && orc.GetComponent<Orc>().isOnTarget == false)
            {
                orc.GetComponent<Orc>().SetEnemy(collision.gameObject.GetComponent<Collider2D>());
            }
   
        }
    }
}
