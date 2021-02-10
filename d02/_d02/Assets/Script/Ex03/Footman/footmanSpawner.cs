﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class footmanSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject footman;
        private float timer;

        private void Start()
        {
            timer = 0f;
           
        }

        private void Update()
        {
            if (timer > 3f)
            {
                timer = 0f;
                Instantiate(footman, transform.position, Quaternion.identity);
            }

                timer += Time.deltaTime;

        }
    }
}
