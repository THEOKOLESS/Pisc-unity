using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class DieSound : MonoBehaviour
    {
        public static DieSound instance { get; private set; }
        [SerializeField] private AudioClip orcDied;
        [SerializeField] private AudioClip HumanDied;

        private AudioSource source;

        private void Awake()
        {
            instance = this;
            source = gameObject.GetComponent<AudioSource>();
        }

        public void PlayOrcDeadClip()
        {
            source.clip = orcDied;
            if (source != null){
                source.Play();
            }
        }


        public void PlayFootmanDeadClip()
        {
            source.clip = HumanDied;
            if (source != null)
                source.Play();
        }
    }
}
