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
        private SpriteRenderer spriteR;
        [SerializeField] private Sprite  buildingCollapseSprite;
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
            // Attack.instance.GetAttacked += Instance_GetAttacked;//someone explain that to me plzz
        }

        private void Start()
        {
            Attack.instance.GetAttacked += Instance_GetAttacked; //dunno why awake doesnt'tWork
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
                case 2:
                    objectName = "Orc forum";
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
                    switch (currentObject)
                    {
                        case 0:
                            GetComponent<PlayerController>().IsDead(true);
                            OrcSound.instance.PlayDeadClip();
                            break;
                        case 1:
                            spriteR = GetComponent<SpriteRenderer>();
                            OrcSound.instance.PlayCollapseClip();
                            spriteR.sprite = buildingCollapseSprite;
                            break;
                        case 2:
                            spriteR = GetComponent<SpriteRenderer>();
                            OrcSound.instance.PlayCollapseClip();
                            spriteR.sprite = buildingCollapseSprite;
                            Debug.Log("The Human Team wins.");
                            Time.timeScale = 0;
                            break;
                    }
                    Destroy(collider2d);
                
                }
            }
        }


        private void Update()
        {
            if (HP == 0 && currentObject == 0)
            {
                timer += Time.deltaTime;
                if (timer > 3f)
                    Destroy(gameObject);
            }
        }

    }
}
