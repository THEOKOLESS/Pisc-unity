using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickController : MonoBehaviour
{
    private Vector3 worldPosition;
    private List<Footman> selectedFootmanList;
    private Footman footman;
    // Start is called before the first frame update
    private void Awake()
    {
        selectedFootmanList = new List<Footman>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            worldPosition.z = 0f;
            GetComponent<PlayerController>().SetMovePosition(worldPosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D collider2D = Physics2D.OverlapPoint(worldPosition, LayerMask.GetMask("Footman"));
            selectedFootmanList.Clear();
            if (collider2D != null)
            {
                footman = collider2D.GetComponent<Footman>();
                if (footman != null)
                {
                    selectedFootmanList.Add(footman);
                }
            }
                Debug.Log(selectedFootmanList.Count);
        }

    }
}

