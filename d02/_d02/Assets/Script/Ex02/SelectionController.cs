using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ex02
{


    public class SelectionController : MonoBehaviour
    {
        private Vector3 worldPosition;
        private List<Footman> footmanSelectedList;
        private Collider2D collider2d;
        private Footman footman;
        private FootmanSound footmanSound;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("ex02");
            footmanSelectedList = new List<Footman>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPosition.z = 0f;

                collider2d = Physics2D.OverlapPoint(worldPosition, LayerMask.GetMask("Footman"));
                if (collider2d != null)
                {
                    footman = collider2d.GetComponent<Footman>();
                    footmanSound = collider2d.GetComponent<FootmanSound>();
                }
                if (!Input.GetKey(KeyCode.LeftControl) && collider2d)
                    ClearFootmanList();
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    if (footmanSelectedList.Count > 0)
                    {
                        footmanSound.playAcknowledgeClip();
                        foreach (Footman footman in footmanSelectedList)
                        {
                            footman.MoveTo(worldPosition);
                        }
                    }
                }
                if (collider2d != null)
                {
                    footmanSound.playSelectedClip();
                    footmanSelectedList.Add(footman);
                    footman.SetSelectedVisible(true);
                }

            }
            if (Input.GetMouseButtonDown(1))
                ClearFootmanList();

        }

        void ClearFootmanList()
        {
            foreach (Footman footman in footmanSelectedList)
            {
                footman.SetSelectedVisible(false);
            }
            footmanSelectedList.Clear();
        }
    }
}