using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public delegate void VoidDelegateGameObject();
    public event VoidDelegateGameObject OnAttack;


    private void Update()
    { 
        OnAttack();
    }
}
