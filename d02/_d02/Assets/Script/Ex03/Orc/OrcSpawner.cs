using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class OrcSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private GameObject orc;
        public static OrcSpawner instance { get; private set; }
        private float _timer;
        private float spawnControle;
        [SerializeField] private List<Collider2D> buildingList;
        private int colliderCount;

        void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _timer = 0f;
            spawnControle = 10f;
            colliderCount = 0;
        }

        private void Update()
        {
            foreach (Collider2D col in buildingList)
            {
                if (col != null)
                    colliderCount += 1;
            }

            switch (colliderCount)
            {
                case 4:
                    colliderCount = 0;
                    spawnControle = 10f;
                    break;
                case 3:
                    colliderCount = 0;
                    spawnControle = 12.5f;
                    break;
                case 2:
                    colliderCount = 0;
                    spawnControle = 15f;
                    break;
                case 1: 
                    colliderCount = 0;
                    spawnControle = 17.5f;
                    break;
                case 10:
                    colliderCount = 0;
                    spawnControle = 20f;
                    break;
            }
            Debug.Log(spawnControle);
            if (_timer > spawnControle)
            {
                _timer = 0f;
                Instantiate(orc, transform.position, Quaternion.identity);
            }

            _timer += Time.deltaTime;

        }
    }
}
