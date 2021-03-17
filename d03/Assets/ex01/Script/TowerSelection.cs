using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler {


    private Canvas canvas2;
    private GameObject m_DraggingIcon;
    [SerializeField] private Sprite towerSprite;
    [SerializeField] private GameObject tower;

    private RectTransform m_DraggingPlane;
    public bool dragOnSurfaces = true;
    //private CanvasGroup canvasGroup;
    private void Awake()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
    }
    static public T FindInParents<T>(GameObject gameObject) where T : Component
    {
        if (gameObject == null) return null;
        var comp = gameObject.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = gameObject.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas2 = FindInParents<Canvas>(gameObject);
        if (canvas2 == null) {
            Debug.Log("No canvas ");
            return;
        }
        m_DraggingIcon = new GameObject("icon");
        m_DraggingIcon.transform.SetParent(canvas2.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();
        var image = m_DraggingIcon.AddComponent<Image>();

        image.sprite = towerSprite;

        image.rectTransform.sizeDelta = new Vector2(20, 20);
  
        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas2.transform as RectTransform;

        SetDraggedPosition(eventData);
        //Debug.Log(rectTransform.anchoredPosition);
        //Instantiate(m_DraggingIcon, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //canvasGroup.blocksRaycasts = false;
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta;
        //m_DraggingIcon.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (m_DraggingIcon != null)
            SetDraggedPosition(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
            Destroy(m_DraggingIcon);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name != "turret_tile" && hit.collider.gameObject.name != "emptyA_0")
                Instantiate(tower, hit.collider.gameObject.transform.position, Quaternion.identity);
            else
                Debug.Log("a turret is already placed here");
        }
    }
     public  void    OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("we click");
    }

    // Update is called once per frame
    void Update()
    {
 

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);    
        //}
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
    }
}