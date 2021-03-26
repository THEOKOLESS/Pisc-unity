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
    public GameObject SetDayzUI;

    [SerializeField] TextMeshProUGUI label;
    private static System.DateTime startDate;
    private static System.DateTime today;
    [SerializeField]  TMP_InputField inputField;
    void Start()
    {
        SetStartDate(-1);
        inputField.characterValidation = TMP_InputField.CharacterValidation.Integer;
        inputField.characterLimit = 5;
    }

    public void SetNumberOfDays()
    {
        if(inputField.text != "")
        {
            int date = int.Parse(inputField.text);
          //  Debug.Log(date);
            if (date < 0)
                date *= -1;   
            SetStartDate((date * -1 ) + 1);
        }

        SexMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = true;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;

        SetDayzUI.GetComponent<CanvasGroup>().alpha = 0f;
        SetDayzUI.GetComponent<CanvasGroup>().interactable = false;
        SetDayzUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public  void IneedToSetUPDayz()
    {
        SetDayzUI.GetComponent<CanvasGroup>().alpha = 1f;
        SetDayzUI.GetComponent<CanvasGroup>().interactable = true;
        SetDayzUI.GetComponent<CanvasGroup>().blocksRaycasts = true;

        SexMenuUI.GetComponent<CanvasGroup>().alpha = 0f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = false;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void IJustMissclicked()
    {
        SexMenuUI.GetComponent<CanvasGroup>().alpha = 1f;
        SexMenuUI.GetComponent<CanvasGroup>().interactable = true;
        SexMenuUI.GetComponent<CanvasGroup>().blocksRaycasts = true;

        SetDayzUI.GetComponent<CanvasGroup>().alpha = 0f;
        SetDayzUI.GetComponent<CanvasGroup>().interactable = false;
        SetDayzUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    void SetStartDate(int dayz)
    {
        if (dayz == -1)
        {
            if (PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
                startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
            else //otherwise...
            {
                startDate = System.DateTime.Today; //save the start date ->
                PlayerPrefs.SetString("DateInitialized", startDate.ToString());
            }
        }
        else
        {
            startDate = System.DateTime.Today.AddDays(dayz); //save the start date ->
            PlayerPrefs.SetString("DateInitialized", startDate.ToString());
        }
    }

 

    private void Update()
    {
        label.text = ("Days Passed since my last time : " + GetDaysPassed());
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
        SetStartDate(1);
  
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
