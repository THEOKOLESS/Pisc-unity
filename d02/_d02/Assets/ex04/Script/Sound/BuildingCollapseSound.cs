using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class BuildingCollapseSound : MonoBehaviour
    {
        public static BuildingCollapseSound instance { get; private set; }
        [SerializeField] private AudioClip buildingCollapse;

        private AudioSource source;

        private void Awake()
        {
            instance = this;
            source = gameObject.GetComponent<AudioSource>();
        }

        public void PlayCollapseClip()
        {
            source.clip = buildingCollapse;
            if (source != null)
                source.Play();
        }
    }

}
