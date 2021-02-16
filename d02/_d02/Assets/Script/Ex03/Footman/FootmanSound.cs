using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class FootmanSound : MonoBehaviour
    {
        // Start is called before the first frame upda

        public AudioSource audioSource;
        public static FootmanSound instance { get; private set; }

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

        [SerializeField] private AudioClip _attack1;
        [SerializeField] private AudioClip _attack2;
        [SerializeField] private AudioClip _attack3;


        private AudioClip[] _acknowledgeArray;
        private AudioClip[] _selectedArray;
        private AudioClip[] _attackArray;
        private AudioClip shootClip;

        void Awake()
        {
            instance = this;
            audioSource = gameObject.GetComponent<AudioSource>();
            _acknowledgeArray = new AudioClip[]{_acknowledge1,_acknowledge2,_acknowledge3,_acknowledge4
            };
            _selectedArray = new AudioClip[]{_selected1, _selected2,_selected3,_selected4, _selected5, _selected6
            };
            _attackArray = new AudioClip[]{_attack1, _attack2, _attack3};
        }


        public void PlayAcknowledgeClip()
        {
            int index = Random.Range(0, _acknowledgeArray.Length);
            shootClip = _acknowledgeArray[index];
            audioSource.clip = shootClip;
            audioSource.Play();
        }

        public void PlaySelectedClip()
        {
            int index = Random.Range(0, _selectedArray.Length);
            shootClip = _selectedArray[index];
            audioSource.clip = shootClip;
            audioSource.Play();
        }

        public void PlayAttackClip()
        {
            int index = Random.Range(0, _attackArray.Length);
            shootClip = _attackArray[index];
            audioSource.clip = shootClip;
            audioSource.Play();
        }


    }
}
