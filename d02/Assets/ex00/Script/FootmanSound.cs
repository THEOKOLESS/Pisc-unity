using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex00
{
    public class FootmanSound : MonoBehaviour
    {
        // Start is called before the first frame upda

        private AudioSource audioSource;
        [SerializeField] private AudioClip _acknowledge1;
        [SerializeField] private AudioClip _acknowledge2;
        [SerializeField] private AudioClip _acknowledge3;
        [SerializeField] private AudioClip _acknowledge4;


        private AudioClip[]   theSounds;
        private AudioClip shootClip;

        void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            theSounds = new AudioClip[]{_acknowledge1,_acknowledge2,_acknowledge3,_acknowledge4
            };
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                playClip();
            }
        }

        public void playClip()
        {
            int index = Random.Range(0, theSounds.Length);
            shootClip = theSounds[index];
            audioSource.clip = shootClip;
            audioSource.Play();
        }
    }
}
