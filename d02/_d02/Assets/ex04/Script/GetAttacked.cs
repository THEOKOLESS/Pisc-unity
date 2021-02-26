using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex04
{
    public class GetAttacked : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private int currentObject;
        private Collider2D collider2d;
        private SpriteRenderer spriteR;
        [SerializeField] private Sprite  buildingCollapseSprite;
        private float timer;

        public  static GetAttacked instance {get; private set;}

        public delegate void VoidDelegateBool(bool isIt);
        public event VoidDelegateBool OnTownAttack;
    

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

        private void    Awake(){
            if (instance == null)
                instance = this;
        }

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
                case 2:
                    objectName = "Orc forum";
                    break;
                case 3:
                    objectName = "Human forum";
                    break;
                case 4:
                    objectName = "Human unit";
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
                
                switch(currentObject){
                    case 0:
                    case 1:
                      FootmanAttackSound.instance.PlayAttackClip();
                      break;
                    case 2:
                        OnTownAttack(true);
                        break;
          
                }
     
                
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
                            BuildingCollapseSound.instance.PlayCollapseClip();
                            spriteR.sprite = buildingCollapseSprite;
                            break;
                        case 2:
                            spriteR = GetComponent<SpriteRenderer>();
                            BuildingCollapseSound.instance.PlayCollapseClip();
                            spriteR.sprite = buildingCollapseSprite;
                            Debug.Log("The Human Team wins.");
                            Time.timeScale = 0;
                            break;
                        case 3:
                            spriteR = GetComponent<SpriteRenderer>();
                            BuildingCollapseSound.instance.PlayCollapseClip();
                            spriteR.sprite = buildingCollapseSprite;
                            Debug.Log("The Orc Team wins.");
                            Time.timeScale = 0;
                            break;
                        case 4:
                            GetComponent<PlayerController>().IsDead(true);
                            OrcSound.instance.PlayDeadClip();
                            GetComponent<Footman>().SetSelectedVisible(false);
                            GetComponent<Footman>().DeleteFromSelection();
                            break;
                    }
                    Destroy(collider2d);
                }
            }
        }


        private void Update()
        {
            if (HP == 0 && (currentObject == 0 || currentObject == 4))
            {
                timer += Time.deltaTime;
                if (timer > 3f)
                    Destroy(gameObject);
            }

            if (currentObject ==  2 &&  Orc.instance != null)
            {
                if(HP == hpMax){
                    timer += Time.deltaTime;
                    if(timer > 2f ){
                          OnTownAttack(false);
                        timer = 0f;
                    }
                }
                else
                {
                    hpMax = hp;
                    timer = 0f;
                }
            }
        }

    }
}
