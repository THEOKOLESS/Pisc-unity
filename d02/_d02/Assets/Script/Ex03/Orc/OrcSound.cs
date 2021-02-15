using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class OrcSound : MonoBehaviour
    {
        public static OrcSound instance { get; private set; }
        [SerializeField] private AudioClip died;
        [SerializeField] private AudioClip buildingCollapse;

        private AudioSource source;

        private void Awake()
        {
            instance = this;
            source = gameObject.GetComponent<AudioSource>();
        }

        public void PlayDeadClip()
        {
            source.clip = died;
            source.Play();
        }

        public void PlayCollapseClip()
        {
            source.clip = buildingCollapse;
            source.Play();
        }

    }
}
