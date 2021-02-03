using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{
    [SerializeField] private GameObject selectedRing;
    private PlayerController movePos;

    private void Awake()
    {
        movePos = GetComponent<PlayerController>();
        SetSelectedVisible(false);
    }

    public  void    SetSelectedVisible(bool visible)
    {
        selectedRing.SetActive(visible);
    }

    public  void    MoveTo(Vector3 targetPos)
    {
        movePos.SetMovePosition(targetPos);
    }
}
