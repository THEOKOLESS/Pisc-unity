using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class OrcSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject orc;
        private float timer;

        private void Start()
        {
            timer = 0f;

        }

        private void Update()
        {
            if (timer > 10f)
            {
                timer = 0f;
                Instantiate(orc, transform.position, Quaternion.identity);
            }

            timer += Time.deltaTime;

        }
    }
}
