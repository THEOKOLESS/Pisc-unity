using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04{


    public class HvOrcAttackedSound : MonoBehaviour
    {
         public static HvOrcAttackedSound instance { get; private set; }

        [SerializeField] private AudioClip hvOrcAttackedSound1;
        [SerializeField] private AudioClip hvOrcAttackedSound2;
        private AudioSource source;


        private AudioClip[] _attackedArray;
        private AudioClip shootClip;

        private void Awake()
        {
            instance = this;
            source = gameObject.GetComponent<AudioSource>();
            _attackedArray = new AudioClip[]{hvOrcAttackedSound1,hvOrcAttackedSound2};
        }

        public void PlayHvOrcAttackedSound()
        {
            int index = Random.Range(0, _attackedArray.Length);
            shootClip = _attackedArray[index];
            source.clip = shootClip;
            if (source != null && !source.isPlaying){
                source.Play();
            }
        }
     

    }
}
