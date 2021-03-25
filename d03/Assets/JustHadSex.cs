using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JustHadSex : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject SexMenuUI;
    public GameObject AreyousureUI;
    public GameObject BravoUI;

    [SerializeField] TextMeshProUGUI label;
    private static System.DateTime startDate;
    private static System.DateTime today;
    void Start()
    {
        SetStartDate();
    }

    void SetStartDate()
    {
        if (PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
        else //otherwise...
        {
            startDate = System.DateTime.Now; //save the start date ->
            PlayerPrefs.SetString("DateInitialized", startDate.ToString());
        }
    }

    private void Update()
    {
        label.text = ("Days Passed : " + GetDaysPassed());
    }
    public static string GetDaysPassed()
    {
        today = System.DateTime.Now;

        //days between today and start date -->
        System.TimeSpan elapsed = today.Subtract(startDate);

        double days = elapsed.TotalDays;

        return days.ToString("0");
    }
    public void IJustHadSex()
    {
        SexMenuUI.GetComponent<CanvasGroup>().alpha = 0f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = false;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        AreyousureUI.GetComponent<CanvasGroup>().alpha = 1f;
        AreyousureUI.GetComponent<CanvasGroup>().interactable = true;
        AreyousureUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void IdidntHadSex()
    {
        AreyousureUI.GetComponent<CanvasGroup>().alpha = 0f;
        AreyousureUI.GetComponent<CanvasGroup>().interactable = false;
        AreyousureUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        SexMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = true;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void IrlyHadSex()
    {
        AreyousureUI.GetComponent<CanvasGroup>().alpha = 0f;
        AreyousureUI.GetComponent<CanvasGroup>().interactable = false;
        AreyousureUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        BravoUI.GetComponent<CanvasGroup>().alpha = 1f;
        BravoUI.GetComponent<CanvasGroup>().interactable = true;
        BravoUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Thanks()
    {
        BravoUI.GetComponent<CanvasGroup>().alpha = 0f;
        BravoUI.GetComponent<CanvasGroup>().interactable = false;
        BravoUI.GetComponent<CanvasGroup>().blocksRaycasts = false;

        SexMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = true;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
