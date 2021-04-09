using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class RadialMenuUI : MonoBehaviour, IPointerClickHandler
{
    public delegate void RadialMenyUIDelegate(RadialMenuUI pUI);

    RadialMenyUIDelegate Callback;

    [SerializeField] TextMeshProUGUI label;
    [SerializeField] TextMeshProUGUI cost;

    [SerializeField] RawImage Icon;
    public  void    SetLabel(string pText)
    {
        label.text = pText;
    }
    public void SetCost(string pText)
    {
        cost.text = pText;
    }
    public void SetIcon(Texture pIcon)
    {
        Icon.texture = pIcon;
        gameObject.AddComponent<Button>();
        //GetComponentInChildren<RawImage>().color = Color.red;
        GetComponent<Button>().targetGraphic = GetComponentInChildren<RawImage>();
    }
    public Texture GetTexture()
    {
        return (Icon.texture);
    }

    public RawImage GetIcon()
    {
        return (Icon);
    }

    public  void SetCallback(RadialMenyUIDelegate pCallback)
    {
        Callback = pCallback;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Callback?.Invoke(this);
    }
}   
 