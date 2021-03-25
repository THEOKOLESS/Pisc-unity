using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour
{
    List<RadialMenuUI> entries;
    [SerializeField] GameObject entryPrefab; // GO menu
    Transform pos;

    private void Start()
    {
        entries = new List<RadialMenuUI>();
    }

    void AddEntry(string pLabel)
    {

      //  GameObject entry = Instantiate(entryPrefab, pos.parent);
        GameObject entry2 = Instantiate(entryPrefab, transform);
        RadialMenuUI rmu = entry2.GetComponent<RadialMenuUI>();
        rmu.SetLabel(pLabel);
        entries.Add(rmu);
    }

  

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))    
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                RaycastHit2D[] hitArray = Physics2D.RaycastAll(hit.collider.gameObject.transform.position, Vector2.zero);
                if (hitArray[0])
                {
                    bool isTower = false;
                    foreach (RaycastHit2D ray in hitArray)
                    {
                        if (ray.collider.gameObject.CompareTag("tower"))
                        {
                            transform.position = ray.collider.gameObject.transform.position;
                         
                            isTower = true;
                        }
                    }
                    if (isTower)
                    {
                        Open();
                    }
                }
            }
        }
    }
    public void Open()
    {

        for(int i=0; i < 3; i++)
        {
            AddEntry("button" + i.ToString());
        }
        Rearrange();
    }

    void Rearrange()
    {
        float radiansOfSepartation = (Mathf.PI * 2) / entries.Count;
        for(int i = 0; i < entries.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSepartation * i) * 50f;
            float y = Mathf.Cos(radiansOfSepartation * i) * 50f;
            entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }
    }
}
