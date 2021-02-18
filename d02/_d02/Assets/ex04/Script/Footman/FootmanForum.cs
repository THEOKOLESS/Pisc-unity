using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class FootmanForum : MonoBehaviour
    {
        public static FootmanForum instance { get; private set; } // singleton
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}
