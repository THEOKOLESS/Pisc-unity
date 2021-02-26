using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ex04
{
    public class OrcForum : MonoBehaviour
    {
        public static OrcForum instance { get; private set; } // singleton
        
        [HideInInspector]public List<Orc> orcList;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start(){
             orcList = new List<Orc>();
        }
        private void Update(){
            //  Debug.Log(orcList.Count);
        }
    }
}

