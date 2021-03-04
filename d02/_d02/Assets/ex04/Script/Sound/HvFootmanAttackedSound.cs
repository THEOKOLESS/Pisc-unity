using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class HvFootmanAttackedSound : MonoBehaviour
    {
        public static HvFootmanAttackedSound instance { get; private set; }
        private AudioSource source;

        private AudioClip[] _attackedArray;
        private AudioClip shootClip;

        [SerializeField] private AudioClip hvFootmanAttackedSound1;
        [SerializeField] private AudioClip hvFootmanAttackedSound2;
        private void Awake()
        {
            instance = this;
            source = gameObject.GetComponent<AudioSource>();
            _attackedArray = new AudioClip[]{hvFootmanAttackedSound1,hvFootmanAttackedSound2};
        }

        public void PlayHvFootmanAttackedSound()
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
