using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex05
{
    public class ammoTower : MonoBehaviour
    {
        private float timer;
        // Update is called once per frame
        void Update()
        {
            if (timer >= 10)
            {
                Destroy(gameObject);
            }
                transform.Translate(2f * Time.deltaTime, 0, 0);
            timer += Time.deltaTime;
        }
    }
}