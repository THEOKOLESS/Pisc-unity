using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04{
    public class FootmanSelectAcknowledgeSound : MonoBehaviour
    {
        private AudioSource audioSource;

        public static FootmanSelectAcknowledgeSound instance { get; private set; }
        [SerializeField] private AudioClip _acknowledge1;
        [SerializeField] private AudioClip _acknowledge2;
        [SerializeField] private AudioClip _acknowledge3;
        [SerializeField] private AudioClip _acknowledge4;

        [SerializeField] private AudioClip _selected1;
        [SerializeField] private AudioClip _selected2;
        [SerializeField] private AudioClip _selected3;
        [SerializeField] private AudioClip _selected4;
        [SerializeField] private AudioClip _selected5;
        [SerializeField] private AudioClip _selected6;


        private AudioClip[] _acknowledgeArray;
        private AudioClip[] _selectedArray;
        private AudioClip shootClip;
        private void Awake(){
            if(instance == null)
                instance = this;
            audioSource = gameObject.GetComponent<AudioSource>();
              _acknowledgeArray = new AudioClip[]{_acknowledge1,_acknowledge2,_acknowledge3,_acknowledge4
            };
             _selectedArray = new AudioClip[]{_selected1, _selected2,_selected3,_selected4, _selected5, _selected6
            };
        }

        public void PlaySelectedClip()
        {
            int index = Random.Range(0, _selectedArray.Length);
            shootClip = _selectedArray[index];
            audioSource.clip = shootClip;
            if (audioSource != null)
                audioSource.Play();
        }

        public void PlayAcknowledgeClip()
        {
            int index = Random.Range(0, _acknowledgeArray.Length);
            shootClip = _acknowledgeArray[index];
            audioSource.clip = shootClip;
            if (audioSource != null)
                audioSource.Play();
        }
    }
}
