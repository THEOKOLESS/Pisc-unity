using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex03
{
    public class GetAttacked : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private int currentObject;
        private Collider2D collider2d;
        private float timer;

        public int HP
        {
            get
            {
                return hp;
            }
            private set
            {
                hp = value;
            }
        }
        private int hpMax;
        private string objectName;

        private void OnEnable()
        {
            //Attack.instance.GetAttacked += Instance_GetAttacked;//someone explain that to me plzz
        }

        private void Start()
        {
            Attack.instance.GetAttacked += Instance_GetAttacked; //someone explain that to me plzz
            collider2d = GetComponent<Collider2D>();
            hpMax = HP;
            switch (currentObject)
            {
                case 0:
                    objectName = "Orc Unit";
                    break;
                case 1:
                    objectName = "Orc building";
                    break;
            }
        }

        private void OnDisable()
        {
            Attack.instance.GetAttacked -= Instance_GetAttacked;
        }

        private void Instance_GetAttacked(Collider2D i)
        {
            if (i == collider2d)
            {
                HP -= 10;
                Debug.LogFormat("{0} [{1} / {2}]HP has been attacked.", objectName, HP, hpMax);
                if (HP < 1)
                {
                    HP = 0;
                    Attack.instance.GetAttacked -= Instance_GetAttacked;
                    GetComponent<PlayerController>().IsDead(true);
                    Destroy(collider2d);
                    switch (currentObject)
                    {
                        case 0:
                            OrcSound.instance.PlayDeadClip();
                            break;
                    }
                }
            }
        }


        private void Update()
        {
            if (HP == 0)
            {
                timer += Time.deltaTime;
                if (timer > 3f)
                    Destroy(gameObject);
            }
        }

    }
}
