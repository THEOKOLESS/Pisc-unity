using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu : MonoBehaviour
{
    List<RadialMenuUI> entries;
    [SerializeField] GameObject entryPrefab; // GO menu
    [SerializeField] List<Texture> Icons;

    private GameObject tower;
    private Vector3 towerPosr;
    private GameObject towerUpagrade;
    private GameObject towerDowngrade;

    private int tmpEnergy;
    private void Start()
    {
        entries = new List<RadialMenuUI>();
    }

    void AddEntry(string pLabel, Texture pIcon, RadialMenuUI.RadialMenyUIDelegate pCallback, int cost )
    {
        GameObject entry2 = Instantiate(entryPrefab, transform);
        RadialMenuUI rmu = entry2.GetComponent<RadialMenuUI>();
        rmu.SetLabel(pLabel);
        rmu.SetIcon(pIcon);
        if((cost * -1) > gameManager.gm.playerEnergy)
            rmu.GetComponentInChildren<RawImage>().color = Color.red; 
        rmu.SetCallback(pCallback);
        if (cost == 0)
        {
          var GO =  rmu.transform.Find("Energy"); 
          GO.gameObject.SetActive(false);
        }
        else if( cost > 0)
            rmu.SetCost("+ " + cost.ToString());
        else
            rmu.SetCost(cost.ToString());
       
        entries.Add(rmu);
    }



    private void Update()
    {
       
        if (Input.GetMouseButtonDown(1))    
        {
            tmpEnergy = gameManager.gm.playerEnergy;
            if (entries.Count > 0)
                Close();
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
                            tower = ray.collider.gameObject.transform.parent.gameObject;
                            towerPosr = tower.transform.position;
                        }
                    }
                    if (isTower)
                    {   
                        towerUpagrade = tower.GetComponent<towerScript>().upgrade;
                        towerDowngrade = tower.GetComponent<towerScript>().downgrade;
                        Open();
                    }
                }
            }  
        }
        if (tmpEnergy != gameManager.gm.playerEnergy)
        {
            tmpEnergy = gameManager.gm.playerEnergy;
            ResetRadialMenu();
        }
         
    }

    private void ResetRadialMenu()
    {
        if (entries.Count > 0)
        {
            Close();
            Open();
        }
    }

    public void Open()
    {
        int upgradeEnergy = 0;
        int downgradeEnergy = tower.GetComponent<towerScript>().energy; 
        string upgradeString = "Max";
        string downgradeString = "Sell";
        if (towerUpagrade)
        {
            upgradeEnergy = towerUpagrade.GetComponent<towerScript>().energy;
            upgradeString = "Upgrade";
        }
        if (towerDowngrade)
            downgradeString = "Downgrade";
       
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    AddEntry(upgradeString , Icons[i], MenuManagere, upgradeEnergy * -1);
                    break;
                case 1:
                    AddEntry("Cancel", Icons[i], MenuManagere, 0);
                    break;
                case 2:
                    AddEntry(downgradeString, Icons[i], MenuManagere, downgradeEnergy / 2);
                    break;
            }
        }
        Rearrange();
    }

    public void Close()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject entry = entries[i].gameObject;
            Destroy(entry);
         }
        entries.Clear();
    }

    private void Downgrade()
    {
        Close();
    
        if (towerDowngrade)
        {
            var old_tower = tower;
            tower = Instantiate(towerDowngrade, towerPosr, Quaternion.identity);
            foreach (Transform child in old_tower.transform)
                GameObject.Destroy(child.gameObject);
            Destroy(old_tower);
            towerDowngrade = tower.GetComponent<towerScript>().downgrade;
            towerUpagrade = tower.GetComponent<towerScript>().upgrade;
            Open();
        }
        else
        {
            foreach (Transform child in tower.transform)
                GameObject.Destroy(child.gameObject);
                Destroy(tower);
        }
        gameManager.gm.playerEnergy += tower.GetComponent<towerScript>().energy / 2;

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

    private void Upgrade()
    {
        Close();
        if (towerUpagrade)
        {
            var old_tower = tower;
            tower = Instantiate(towerUpagrade, towerPosr, Quaternion.identity);
            foreach (Transform child in old_tower.transform)
                GameObject.Destroy(child.gameObject);
            Destroy(old_tower);
        }
        towerUpagrade = tower.GetComponent<towerScript>().upgrade;
        towerDowngrade = tower.GetComponent<towerScript>().downgrade;
        gameManager.gm.playerEnergy -= tower.GetComponent<towerScript>().energy;
        Open();
    }
    void MenuManagere(RadialMenuUI pUI)
    {
        if (pUI.GetTexture() == Icons[0] && pUI.GetIcon().color != Color.red && towerUpagrade)
            Upgrade();
        if (pUI.GetTexture() == Icons[1])
            Close();
        if (pUI.GetTexture() == Icons[2])
            Downgrade();
     
    }
}
