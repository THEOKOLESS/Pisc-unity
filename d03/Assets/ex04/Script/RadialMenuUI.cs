using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadialMenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;

    public  void    SetLabel(string pText)
    {
        label.text = pText;
    }
}
