using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ex04
{
    public class OrcForum : MonoBehaviour
    {
        public static OrcForum instance { get; private set; } // singleton

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

   
        private void Update(){
            //  Debug.Log(orcList.Count);
        }
    }
}

