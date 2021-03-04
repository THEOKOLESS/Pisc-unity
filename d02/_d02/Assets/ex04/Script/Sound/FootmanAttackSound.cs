using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class FootmanAttackSound : MonoBehaviour
    {
        // Start is called before the first frame upda

        private AudioSource audioSource;
        public static FootmanAttackSound instance { get; private set; }

        [SerializeField] private AudioClip _attack1;
        [SerializeField] private AudioClip _attack2;
        [SerializeField] private AudioClip _attack3;


  
        private AudioClip[] _attackArray;
        private AudioClip shootClip;

        void Awake()
        {
            instance = this;
            audioSource = gameObject.GetComponent<AudioSource>();
            _attackArray = new AudioClip[]{_attack1, _attack2, _attack3};
        }


     
        public void PlayAttackClip()
        {
            int index = Random.Range(0, _attackArray.Length);
            shootClip = _attackArray[index];
            audioSource.clip = shootClip;
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }
        
        public void PlayOrcAttackClip()
        {
            audioSource.clip = _attack3;
            if (audioSource != null && !audioSource.isPlaying)
                audioSource.Play();
        }

    }
}
